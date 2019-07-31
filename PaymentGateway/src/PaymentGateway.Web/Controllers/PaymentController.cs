using Common.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Core;
using PaymentGateway.Core.Common.DataContract;
using System;

namespace PaymentGateway.Web.Controllers
{
    /// <summary>
    /// Payment related api endpoint.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentManager _paymentManager;

        public PaymentController(IPaymentManager paymentManager)
        {
            Check.NotNull(paymentManager, nameof(paymentManager));

            _paymentManager = paymentManager;
        }

        /// <summary>
        /// Returns an existing payment details
        /// </summary>
        /// <param name="id">The payment unique identifier</param>
        /// <returns>The payment details as <see cref="Payment"/>.</returns>
        [HttpGet("{id}")]
        public ActionResult<Payment> Get(Guid id)
        {
            return Ok(_paymentManager.GetById(id));
        }

        /// <summary>
        /// Forwards the payment request to the bank service
        /// </summary>
        /// <param name="request">The requested payment as <see cref="PaymentRequest"/>.</param>
        /// <returns>The results of the payment request as <see cref="PaymentResponse"/>.</returns>
        [HttpPost]
        public ActionResult<PaymentResponse> Post([FromBody] PaymentRequest request)
        {
            return Ok(_paymentManager.ProcessPayment(request));
        }
    }
}
