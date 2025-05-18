using System;

using PaymentSystem.Strategies;



namespace PaymentSystem
{
    public abstract class Invoice
    {
        public string InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public Invoice()
        {
            InvoiceNumber = GenerateInvoiceNumber();
            IssueDate = DateTime.Now;
        }
        public ITaxStrategy TaxStrategy { get; set; }

        public decimal CalculateTotal()
        {
        return Amount + (TaxStrategy?.CalculTaxa(this) ?? 0);
        }


        protected abstract string GenerateInvoiceNumber();
        public abstract void GenerateInvoice();
        public abstract string GetServiceType();
    }
} 