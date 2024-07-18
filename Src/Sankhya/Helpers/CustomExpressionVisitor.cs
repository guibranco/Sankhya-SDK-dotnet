using System.Linq.Expressions;

namespace Sankhya.Helpers
{
    public class CustomExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            return base.VisitBinary(node);
        }
    }
}
