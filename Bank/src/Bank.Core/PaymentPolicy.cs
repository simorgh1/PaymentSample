using System.Collections.Generic;
using Bank.Infrastructure.Entities;

namespace Bank.Core
{
    public class PaymentPolicy
    {
        public decimal MaxAllowedAmount { get;}
        public decimal MinAllowedAmount { get; }
        public List<Currency> AllowedCurrencies { get;}

        public PaymentPolicy()
        {
            // set default payment policy

            MaxAllowedAmount = 100m;
            MinAllowedAmount = 1m;

            AllowedCurrencies = new List<Currency> {
                new Currency {Name = "Euro", Code = "EUR"},
                new Currency {Name = "British Pound", Code = "GBP"},
                new Currency {Name = "Swiss Franc", Code = "CHF"}
            };
        }
    }
}
