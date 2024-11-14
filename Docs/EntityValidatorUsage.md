# Entity Validator Usage

The `EntityValidator` is a utility designed to ensure that all entity classes adhere to defined standards, enhancing code quality and maintainability. This document provides guidelines on how to use the validator, integrate it into existing workflows, and interpret validation results.

## Usage Guidelines

### Scanning Assemblies

To validate entities within an assembly, use the `ValidateEntities` method:

```csharp
using System.Reflection;
using Sankhya.Validation;

var assembly = Assembly.GetExecutingAssembly();
EntityValidator.ValidateEntities(assembly);
```

### Validation Rules

The validator checks for the following compliance rules:
- Entities must have a parameterless constructor.
- Additional rules can be added as needed.

### Error Handling

If an entity does not comply with the validation rules, an `InvalidOperationException` will be thrown with a descriptive error message.

## Examples

### Compliant Entity

```csharp
[Entity("CompliantEntity")]
public class CompliantEntity : IEntity
{
    public CompliantEntity() { }
}
```

### Non-Compliant Entity

```csharp
[Entity("NonCompliantEntity")]
public class NonCompliantEntity : IEntity
{
    public NonCompliantEntity(string param) { }
}
```

## Integration

Integrate the validator into your unit testing suite to automatically verify entity compliance during test runs. Consider runtime integration to ensure ongoing compliance during application execution.
