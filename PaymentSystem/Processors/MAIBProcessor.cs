using System;

namespace PaymentSystem
{
    public class MAIBProcessor : PaymentProcessor
    {
        public override bool ProcessPayment(decimal amount, string currency)
        {
            // Simulăm procesarea plății prin MAIB
            Console.WriteLine($"Procesare plată MAIB: {amount} {currency}");
            return true;
        }

        public override string GetPaymentMethodName()
        {
            return "MAIB";
        }
    }
} 