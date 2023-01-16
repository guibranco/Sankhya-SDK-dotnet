namespace Sankhya.Tests
{
    using System;
    using Sankhya.Attributes;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            const string name = "test";
            var entityAttribute = new EntityAttribute(name);
            var result = entityAttribute.Name;
            Assert.Equal(name, result);
        }
    }
}
