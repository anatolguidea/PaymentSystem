using System;

namespace PaymentSystem
{
    public class MPayProcessor : PaymentProcessor
    {
        public override bool ProcessPayment(decimal amount, string currency)
        {
            // Simulăm procesarea plății prin MPay
            Console.WriteLine($"Procesare plată MPay: {amount} {currency}");
            return true;
        }

        public override string GetPaymentMethodName()
        {
            return "MPay";
        }
    }
} 