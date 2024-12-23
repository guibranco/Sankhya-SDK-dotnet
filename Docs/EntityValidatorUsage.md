# Entity Validator Usage

The `EntityValidator` is a utility designed to ensure that all entity classes in the **Sankhya-SDK-dotnet** repository comply with defined structural and behavioral constraints. This document provides guidance on how to use the validator, integrate it into existing workflows, and understand the validation rules and error messages.

## How to Use the Entity Validator

### Scanning Assemblies

To validate entities, the `EntityValidator` scans assemblies to identify classes decorated with the `EntityAttribute` or those implementing the `IEntity` interface.

```csharp
using System.Reflection;
using Sankhya.Validation;

var assembly = Assembly.GetExecutingAssembly();
EntityValidator.ValidateEntities(assembly);
```

### Validation Rules

The validator checks each identified class to ensure it meets the following criteria:

#### Entity Class Requirements

- The class is public.
- It has an `EntityAttribute` specifying the entity name.
- It inherits from the `IEntity` interface.
- It includes a parameterless constructor.
- It implements the `IEquatable` interface.

#### Property Constraints

- Every public property has one of the required attributes: `EntityElementAttribute`, `EntityIgnoreAttribute`, or `EntityReferenceAttribute`.
- For properties with `EntityElementAttribute`, a corresponding `ShouldSerialize{PropertyName}` method exists to determine if the property needs serialization.

## Integration into Workflows

The `EntityValidator` can be integrated into unit tests to automatically check entity compliance during test runs. It can also be run at application startup or during relevant operations to enforce compliance dynamically.

## Error Messages

If an entity does not comply with the validation rules, the `EntityValidator` will throw an `InvalidOperationException` with a message indicating the specific rule that was violated.
