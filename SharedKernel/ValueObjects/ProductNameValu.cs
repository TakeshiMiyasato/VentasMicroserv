using ShareKernel.Core;
using ShareKernel.Rules;

namespace ShareKernel.ValueObjects
{
    public record ProductNameValue : ValueObject
    {
        public string Name { get; }

        public ProductNameValue(string name)
        {
            CheckRule(new StringNotNullOrEmptyRule(name));
            if(name.Length > 500)
            {
                throw new BussinessRuleValidationException("ProductName can't be more than 500 characters");
            }
            Name = name;
        }

        public static implicit operator string(ProductNameValue value)
        {
            return value.Name;
        }

        public static implicit operator ProductNameValue(string name)
        {
            return new ProductNameValue(name);
        }
    }
}
