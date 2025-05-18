using System;

namespace PaymentSystem
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(decimal amount, string currency);
        string GetPaymentMethodName();
    }
} 