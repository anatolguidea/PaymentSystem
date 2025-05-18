namespace PaymentSystem.Models
{
    public class InvoiceRequest
    {
        public string ServiceType { get; set; } = string.Empty;
        public decimal PreviousReading { get; set; }
        public decimal CurrentReading { get; set; }
        public decimal Rate { get; set; }
    }

    public class InvoiceAndPaymentRequest : InvoiceRequest
    {
        public string PaymentMethod { get; set; } = string.Empty;
    }

    public class PaymentRequest
    {
        public string PaymentMethod { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "MDL";
        public bool HasSufficientFunds { get; set; }
    }

    public class QuickPaymentRequest
    {
        public string ServiceType { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
    }

    public class TaxCalculationRequest
    {
        public string ServiceType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }

    public class PaymentValidationRequest
    {
        public decimal Amount { get; set; }
        public bool HasSufficientFunds { get; set; }
    }
} 