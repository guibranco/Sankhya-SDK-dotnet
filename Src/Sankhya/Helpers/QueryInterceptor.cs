using System.Linq;

namespace Sankhya.Helpers
{
    public class QueryInterceptor<T>
    {
        public IQueryable<T> Intercept(IQueryable<T> query)
        {
            return query;
        }
    }