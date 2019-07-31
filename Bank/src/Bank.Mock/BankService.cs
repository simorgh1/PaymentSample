using Bank.Core;
using Bank.Core.Common.DataContract;
using Bank.Core.Interfaces;
using System;
using System.Linq;
using Common.Diagnostics;
using Bank.Core.Validators;

namespace Bank.Mock
{
    public class BankService : IBankService
    {
        private readonly PaymentPolicy _paymentPolicy;

        public BankService(PaymentPolicy paymentPolicy)
        {
            Check.NotNull(paymentPolicy, nameof(paymentPolicy));

            _paymentPolicy = paymentPolicy;
        }

        /// <summary>
        /// Simulates a payment authorization, invalid expiry or card number or a payment does not match the payment policy returns false as status
        /// </summary>
        /// <param name="paymentAuthorizationRequest"></param>
        /// <returns>Indicating the current payment authorization response in <see cref="PaymentAuthorizationResponse"/>.</returns>
        public PaymentAuthorizationResponse AuthorizePayment(
            PaymentAuthorizationRequest paymentAuthorizationRequest)
        {
            // Check payment based on the payment policy
            if (_paymentPolicy.MaxAllowedAmount < paymentAuthorizationRequest.Amount ||
                _paymentPolicy.MinAllowedAmount > paymentAuthorizationRequest.Amount ||
                _paymentPolicy.AllowedCurrencies.Count(c=> c.Code == paymentAuthorizationRequest.Currency) == 0 ||
                !ExpiryValidator.Validate(paymentAuthorizationRequest.Expiry) ||
                !CardNumberValidator.Validate(paymentAuthorizationRequest.CardNumber))
            {
                return new PaymentAuthorizationResponse(Guid.NewGuid(), false);
            }

            return new PaymentAuthorizationResponse(Guid.NewGuid(), true);
        }
    }
}
