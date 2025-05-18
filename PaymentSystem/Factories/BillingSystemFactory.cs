using System;
using PaymentSystem.Factories;
using PaymentSystem.Models;


namespace PaymentSystem
{
    public class BillingSystemFactory : IBillingSystemFactory
    {
        private readonly InvoiceFactory _invoiceFactory;
        private readonly PaymentFactory _paymentFactory;

        public BillingSystemFactory()
        {
            _invoiceFactory = new InvoiceFactory();
            _paymentFactory = new PaymentFactory();
        }

        public Invoice CreateInvoice(string serviceType, decimal previousReading, decimal currentReading, decimal rate)
        {
            return _invoiceFactory.CreateInvoice(serviceType, previousReading, currentReading, rate);
        }

        public IPaymentProcessor CreatePaymentProcessor(string paymentMethod)
        {
            return _paymentFactory.CreatePaymentProcessor(paymentMethod);
        }
    }
} 