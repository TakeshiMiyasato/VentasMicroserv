using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.ValueObjects
{
    public record CantidadValue : ValueObject
    {
        public int Value { get; }
        public CantidadValue(int value)
        {
            if (value < 0)
            {
                throw new BussinessRuleValidationException("Cantidad value cannot be negative");
            }
            Value = value;
        }

        public static implicit operator int(CantidadValue value)
        {
            return value.Value;
        }

        public static implicit operator CantidadValue(int value)
        {
            return new CantidadValue(value);
        }
    }
}
