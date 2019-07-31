# Payment Gateway

Payment Gateway validates requests, stores the card information and forwards the payment requests to the acquiring bank. The response of the payment is responded back to the merchant including a unique identifier and the status of the payment processing.

The Bank Service simulates a payment authorization based on a default payment policy that defines the allowed currencies, min/max allowed amount.

## How to use

[Note]: .Net Core 2.1 should be pre-installed.

Build PaymentGateway solution and start PaymentGateway.Web REST api project. It will startup the swagger UI, where you could test the Payment endpoint.

- Post /api/payment validates the payment request and after that it forwards the payment request to the Bank Service simulator, then the payment with its status from the Bank Service is stored and the response contains the unique identifier and the success status of the payment. 
- Get /api/payment/id returns details of a previously made payment. This includes card number information and the success status of the payment. 
