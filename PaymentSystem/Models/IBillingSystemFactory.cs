using System;

namespace PaymentSystem
{
    public interface IBillingSystemFactory
    {
        Invoice CreateInvoice(string serviceType, decimal previousReading, decimal currentReading, decimal rate);
        IPaymentProcessor CreatePaymentProcessor(string paymentMethod);
    }
}       