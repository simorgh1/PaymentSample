using Bank.Core.Diagnostics;
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

        [HttpGet("{id}")]
        public ActionResult<Payment> Get(Guid id)
        {
            return Ok(_paymentManager.GetById(id));
        }

        [HttpPost]
        public ActionResult<PaymentResponse> Post([FromBody] PaymentRequest request)
        {
            return Ok(_paymentManager.ProcessPayment(request));
        }
    }
}
