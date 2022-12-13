using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.ValueObjects
{
    public record TelefonoValue : ValueObject
    {
        public string Telefono { get; }
        public TelefonoValue(string value)
        {
            if(value == null || value == string.Empty)
            {
                throw new BussinessRuleValidationException("El numero telefonico no puede ser nulo o vacio");
            }
            Telefono = value;
        }

        public static implicit operator string(TelefonoValue value)
        {
            return value.Telefono;
        }

        public static implicit operator TelefonoValue(string value)
        {
            return new TelefonoValue(value);
        }
    }
}
