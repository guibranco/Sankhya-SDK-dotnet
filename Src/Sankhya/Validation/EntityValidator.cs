using System;
using System.Linq;
using System.Reflection;

namespace Sankhya.Validation
{
    public static class EntityValidator
    {
        public static void ValidateEntities(Assembly assembly)
        {
            var entityTypes = assembly.GetTypes()
                .Where(t => t.GetCustomAttributes(typeof(EntityAttribute), false).Any() ||
                            typeof(IEntity).IsAssignableFrom(t));

            foreach (var type in entityTypes)
            {
                ValidateEntity(type);
            }
        }

        private static void ValidateEntity(Type type)
        {
            // Implement validation rules here
            // Example: Check for a parameterless constructor
            if (type.GetConstructor(Type.EmptyTypes) == null)
            {
                throw new InvalidOperationException($"Entity {type.Name} must have a parameterless constructor.");
            }

            // Add more validation rules as needed
        }
    }
}

