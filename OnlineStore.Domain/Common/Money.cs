using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Common
{
    public class Money :ValueObject
    {
        public Money()
        {

        }
        public Money(int value)
        {
            if (value >= 0)
            {
                Value = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Price can not be less than zero");
            }
        }
        public int Value { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static Money operator +(Money one, Money two)
        {
            return new Money(one.Value + two.Value);
        }
        public static Money operator -(Money one, Money two)
        {
            return new Money(one.Value - two.Value);
        }
        public static Money operator *(Money one, Money two)
        {
            return new Money(one.Value * two.Value);
        }
        public static Money operator /(Money one, Money two)
        {
            return new Money(one.Value / two.Value);
        }
    }
}
