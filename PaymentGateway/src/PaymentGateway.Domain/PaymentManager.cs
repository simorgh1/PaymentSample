
using Bank.Core.Common.DataContract;
using Bank.Core.Interfaces;
using PaymentGateway.Core;
using PaymentGateway.Core.Common.DataContract;
using PaymentGateway.Core.Interfaces;
using System;
using System.Linq;

namespace PaymentGateway.Domain
{
    public class PaymentManager : IPaymentManager
    {
        private readonly IRepository _paymentRepository;
        private readonly IBankService _bankService;

        public PaymentManager(
            IRepository paymentRepository,
            IBankService bankService
            )
        {
            _paymentRepository = paymentRepository;
            _bankService = bankService;
        }

        public Payment GetById(Guid paymentId)
        {
            var payment = _paymentRepository.GetById<PaymentGateway.Core.Entities.Payment>(paymentId);

            return Map(payment);
            
        }

        /// <summary>
        /// All payment requests are processed and persisted. Bank Service mock respondes the current  payment status
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <returns></returns>
        public PaymentResponse ProcessPayment(PaymentRequest paymentRequest)
        {
            PaymentAuthorizationResponse paymentAuthorizationResponse = null;
            var paymentAuthorizationRequest = new PaymentAuthorizationRequest(
                paymentRequest.CardNumber,
                paymentRequest.Expiry,
                paymentRequest.Amount,
                paymentRequest.Cvv,
                paymentRequest.Currency
                );

            paymentAuthorizationResponse = _bankService.AuthorizePayment(paymentAuthorizationRequest);

            var payment = new Core.Entities.Payment()
            {
                CardNumber = MaskCardNumber(paymentRequest.CardNumber),
                Cvv = paymentRequest.Cvv,
                Expiry = paymentRequest.Expiry,
                Currency = paymentRequest.Currency,
                Amount = paymentRequest.Amount,
                SuccessStatus = paymentAuthorizationResponse.SuccessStatus
            };

            _paymentRepository.Add(payment);

            return new PaymentResponse(payment.Id, payment.SuccessStatus);
        }

        private string MaskCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
                return null;

            // invalid credit card number
            if (cardNumber.Length != 16)
                return cardNumber;

            // basic credit card number masking, all numbers except the last 4 digits are starred
            return $"************{cardNumber.Substring(12,4)}";
        }

        private Payment Map(Core.Entities.Payment payment)
        {
            if (payment == null)
                return default(Payment);

            return new Payment()
            {
                Id = payment.Id.ToString(),
                Currency = payment.Currency,
                Cvv = payment.Cvv,
                Amount = payment.Amount,
                CardNumber = payment.CardNumber,
                SuccessStatus = payment.SuccessStatus,
                Expiry = payment.Expiry
            };
        }
    }
}
