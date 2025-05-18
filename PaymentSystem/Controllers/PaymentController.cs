using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Factories;
using PaymentSystem.Models;
using PaymentSystem.Strategies;
using PaymentSystem.Decorators;
using PaymentSystem.Validators;
using PaymentSystem.Commands;

namespace PaymentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly InvoiceFactory _invoiceFactory;
        private readonly BillingSystemFactory _billingSystem;
        private readonly PaymentFactory _paymentFactory;

        public PaymentController()
        {
            _invoiceFactory = new InvoiceFactory();
            _billingSystem = new BillingSystemFactory();
            _paymentFactory = new PaymentFactory();
        }

        [HttpPost("generate-invoice")]
        public IActionResult GenerateInvoice([FromBody] InvoiceRequest request)
        {
            try
            {
                var invoice = _invoiceFactory.CreateInvoice(
                    request.ServiceType,
                    request.PreviousReading,
                    request.CurrentReading,
                    request.Rate
                );
                invoice.GenerateInvoice();
                return Ok(new { message = "Factură generată cu succes", amount = invoice.Amount });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("generate-invoice-and-payment")]
        public IActionResult GenerateInvoiceAndPayment([FromBody] InvoiceAndPaymentRequest request)
        {
            try
            {
                var invoice = _billingSystem.CreateInvoice(
                    request.ServiceType,
                    request.PreviousReading,
                    request.CurrentReading,
                    request.Rate
                );
                var processor = _billingSystem.CreatePaymentProcessor(request.PaymentMethod);

                invoice.GenerateInvoice();
                processor.ProcessPayment(invoice.Amount, invoice.Currency);

                return Ok(new { message = "Factură și plată procesate cu succes" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("process-payment")]
        public IActionResult ProcessPayment([FromBody] PaymentRequest request)
        {
            try
            {
                var processor = _paymentFactory.CreatePaymentProcessor(request.PaymentMethod);
                processor.ProcessPayment(request.Amount, request.Currency);
                return Ok(new { message = "Plată procesată cu succes" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("quick-payment")]
        public IActionResult QuickPayment([FromBody] QuickPaymentRequest request)
        {
            try
            {
                var facade = new PaymentSystem.Services.PaymentFacade();
                facade.ProceseazaPlata(request.ServiceType, request.PaymentMethod);
                return Ok(new { message = "Plată rapidă procesată cu succes" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("payment-with-logging")]
        public IActionResult PaymentWithLogging([FromBody] PaymentRequest request)
        {
            try
            {
                var baseProcessor = _paymentFactory.CreatePaymentProcessor(request.PaymentMethod);
                var loggedProcessor = new LoggingPaymentProcessor(baseProcessor);
                loggedProcessor.ProcessPayment(request.Amount, request.Currency);
                return Ok(new { message = "Plată cu logare procesată cu succes" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("calculate-tax")]
        public IActionResult CalculateTax([FromBody] TaxCalculationRequest request)
        {
            try
            {
                var invoice = _invoiceFactory.CreateInvoice(request.ServiceType, 0, 0, 0);
                invoice.Amount = request.Amount;

                invoice.TaxStrategy = request.ServiceType.ToUpper() switch
                {
                    "ELECTRICITY" => new ElectricityTaxStrategy(),
                    "WATER" => new WaterTaxStrategy(),
                    _ => throw new ArgumentException("Tip de serviciu invalid")
                };

                var total = invoice.CalculateTotal();
                return Ok(new { total });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("validate-payment-chain")]
        public IActionResult ValidatePaymentChain([FromBody] PaymentValidationRequest request)
        {
            try
            {
                var validator1 = new AmountValidator();
                var validator2 = new FundsValidator();
                validator1.SetNext(validator2);

                var result = validator1.Validate(new PaymentRequest
                {
                    Amount = request.Amount,
                    HasSufficientFunds = request.HasSufficientFunds
                });

                return Ok(new { isValid = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("validate-payment-command")]
        public IActionResult ValidatePaymentCommand([FromBody] PaymentValidationRequest request)
        {
            try
            {
                var paymentRequest = new PaymentRequest
                {
                    Amount = request.Amount,
                    HasSufficientFunds = request.HasSufficientFunds
                };

                var invoker = new PaymentInvoker();
                invoker.AddCommand(new ValidateAmountCommand(paymentRequest));
                invoker.AddCommand(new ValidateFundsCommand(paymentRequest));

                invoker.ExecuteAll();
                return Ok(new { message = "Plată validată cu succes" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
} 