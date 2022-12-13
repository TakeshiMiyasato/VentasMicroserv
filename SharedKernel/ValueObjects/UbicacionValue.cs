using ShareKernel.Core;
using ShareKernel.Rules;

namespace ShareKernel.ValueObjects
{
    public record UbicacionValue : ValueObject
    {
        public string Name { get; }

        public UbicacionValue(string name)
        {
            CheckRule(new StringNotNullOrEmptyRule(name));
            if(name.Length > 500)
            {
                throw new BussinessRuleValidationException("UbicacionValue can't be more than 500 characters");
            }
            Name = name;
        }

        public static implicit operator string(UbicacionValue value)
        {
            return value.Name;
        }

        public static implicit operator UbicacionValue(string name)
        {
            return new UbicacionValue(name);
        }
    }
}
