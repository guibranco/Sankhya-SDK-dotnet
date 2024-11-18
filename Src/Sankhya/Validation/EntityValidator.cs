using System;
using System.Linq;
using System.Reflection;
using Sankhya.Attributes;

namespace Sankhya.Validation;

public static class EntityValidator
{
    public static void ValidateEntities(Assembly assembly)
    {
        var entityTypes = assembly.GetTypes()
            .Where(t => t.IsClass && t.IsPublic && t.GetCustomAttribute<EntityAttribute>() != null);

        foreach (var type in entityTypes)
        {
            ValidateEntity(type);
        }
    }

    private static void ValidateEntity(Type type)
    {
        if (!typeof(IEntity).IsAssignableFrom(type))
            throw new InvalidOperationException($"{type.Name} must implement IEntity interface.");

        if (type.GetConstructor(Type.EmptyTypes) == null)
            throw new InvalidOperationException($"{type.Name} must have a parameterless constructor.");

        // Additional validation rules can be added here
    }
}
