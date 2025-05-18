using System;

namespace PaymentSystem.Services
{
    public class MPayService
    {
        public bool MakePayment(decimal sum, string currencyCode)
        {
            // Simulăm procesarea plății prin MPay
            Console.WriteLine($"Procesare plată MPay: {sum} {currencyCode}");
            return true;
        }

        public string GetServiceName()
        {
            return "MPay";
        }
    }
} 