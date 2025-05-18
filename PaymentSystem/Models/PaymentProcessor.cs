using System;

namespace PaymentSystem
{
    public abstract class PaymentProcessor
    {
        public abstract bool ProcessPayment(decimal amount, string currency);
        public abstract string GetPaymentMethodName();
    }
} 