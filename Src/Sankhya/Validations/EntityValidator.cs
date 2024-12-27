using System;
using System.Linq;
using System.Reflection;
using Sankhya.Attributes;
using Sankhya.Transport;

namespace Sankhya.Validations;

/// <summary>
/// Provides functionality to validate entity types within an assembly.
/// </summary>
public static class EntityValidator
{
    /// <summary>
    /// Validates all entity types within the specified assembly.
    /// </summary>
    /// <param name="assembly">The assembly containing the entity types to validate.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if any entity type does not meet the required validation rules.
    /// </exception>
    public static void ValidateEntities(Assembly assembly)
    {
        var types = assembly.GetTypes();

        var entityTypes = types.Where(t =>
            t.GetCustomAttribute<EntityAttribute>() != null || typeof(IEntity).IsAssignableFrom(t)
        );

        foreach (var type in entityTypes)
        {
            ValidateEntityType(type);
        }
    }

    /// <summary>
    /// Validates a specific entity type to ensure it meets the required constraints.
    /// </summary>
    /// <param name="type">The entity type to validate.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the entity type does not meet the required validation rules.
    /// </exception>
    private static void ValidateEntityType(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) == null)
        {
            throw new InvalidOperationException(
                $"Entity {type.Name} must have a parameterless constructor."
            );
        }

        var hasEntityAttribute = type.GetCustomAttribute<EntityAttribute>() != null;
        var inheritsIEntity = typeof(IEntity).IsAssignableFrom(type);

        if (!hasEntityAttribute || !inheritsIEntity)
        {
            throw new InvalidOperationException(
                $"The type {type.FullName} must have both EntityAttribute and implement IEntity."
            );
        }

        if (!ImplementsIEquatable(type))
        {
            throw new InvalidOperationException(
                $"The type {type.FullName} must implement IEquatable<{type.Name}>."
            );
        }

        foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            ValidateProperty(type, property);
        }
    }

    /// <summary>
    /// Validates a specific property of an entity type to ensure it meets the required constraints.
    /// </summary>
    /// <param name="type">The type of the entity containing the property.</param>
    /// <param name="property">The property to validate.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the property does not meet the required validation rules.
    /// </exception>
    private static void ValidateProperty(Type type, PropertyInfo property)
    {
        var hasValidAttribute = property
            .GetCustomAttributes()
            .Any(attr =>
                attr is EntityElementAttribute
                || attr is EntityIgnoreAttribute
                || attr is EntityReferenceAttribute
            );

        if (!hasValidAttribute)
        {
            throw new InvalidOperationException(
                $"The property {type.FullName}.{property.Name} must have one of the valid attributes: "
                    + $"EntityElementAttribute, EntityIgnoreAttribute, or EntityReferenceAttribute."
            );
        }

        if (property.GetCustomAttribute<EntityElementAttribute>() == null)
        {
            return;
        }

        var methodName = $"ShouldSerialize{property.Name}";
        var method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);

        if (
            method == null
            || method.ReturnType != typeof(bool)
            || method.GetParameters().Length != 0
        )
        {
            throw new InvalidOperationException(
                $"The type {type.FullName} must have a method {methodName} with the signature 'bool {methodName}()'."
            );
        }
    }

    /// <summary>
    /// Determines whether the specified type implements <see cref="IEquatable{T}"/>.
    /// </summary>
    /// <param name="type">The type to check.</param>
    /// <returns><c>true</c> if the type implements <see cref="IEquatable{T}"/>; otherwise, <c>false</c>.</returns>
    internal static bool ImplementsIEquatable(Type type)
    {
        var equatableInterface = typeof(IEquatable<>).MakeGenericType(type);
        return equatableInterface.IsAssignableFrom(type);
    }
}
