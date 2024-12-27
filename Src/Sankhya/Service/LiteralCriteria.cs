using System;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace Sankhya.Service;

public sealed class LiteralCriteria : ILiteralCriteria
{
    [XmlElement(ElementName = "expression")]
    [Localizable(false)]
    public string Expression { get; set; }

    [XmlElement(ElementName = "parameter")]
    public Parameter[] Parameters { get; set; }

    public LiteralCriteria() { }

    public LiteralCriteria([Localizable(false)] string expression) => Expression = expression;

    public LiteralCriteria(StringBuilder expressionBuilder)
    {
        if (expressionBuilder == null)
        {
            throw new ArgumentNullException(nameof(expressionBuilder));
        }

        Expression = expressionBuilder.ToString();
    }
}
