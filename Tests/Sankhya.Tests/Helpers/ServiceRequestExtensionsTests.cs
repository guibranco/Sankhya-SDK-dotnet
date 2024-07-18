using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sankhya.Helpers;
using Sankhya.Transport;
using Xunit;

namespace Sankhya.Tests.Helpers
{
    public class ServiceRequestExtensionsTests
    {
        [Fact]
        public void Resolve_ShouldReturnFilteredResults()
        {
            IQueryable<IEntity> entities = new List<IEntity>().AsQueryable();
            Expression<Func<IEntity, bool>> predicate = e => true;
            var result = entities.Resolve(predicate);
            Assert.NotNull(result);
        }
    }
}
