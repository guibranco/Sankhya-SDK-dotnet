namespace Sankhya.Tests.Attributes
{
    using System;
    using Sankhya.Attributes;
    using Xunit;

    public class EntityAttributeTests
    {
        [Fact]
        public void SetAttributeName_NamePropertyShouldBeEqual()
        {
            const string name = "test";
            var entityAttribute = new EntityAttribute(name);
            var result = entityAttribute.Name;
            Assert.Equal(name, result);
        }
    }
}
