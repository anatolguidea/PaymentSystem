using System;

namespace PaymentSystem.Services
{
    public class MAIBService
    {
        public bool ExecutePayment(decimal value, string currencyType)
        {
            // Simulăm procesarea plății prin MAIB
            Console.WriteLine($"Procesare plată MAIB: {value} {currencyType}");
            return true;
        }

        public string GetBankName()
        {
            return "MAIB";
        }
    }
} 