using System;
using PaymentSystem.Services;

namespace PaymentSystem.Factories

{
    public class PaymentFactory
    {
        public IPaymentProcessor CreatePaymentProcessor(string paymentMethod)
        {
            switch (paymentMethod.ToUpper())
            {
                case "MPAY":
                    var mpayService = new MPayService();
                    return new MPayAdapter(mpayService);
                case "MAIB":
                    var maibService = new MAIBService();
                    return new MAIBAdapter(maibService);
                default:
                    throw new ArgumentException($"Metoda de plată {paymentMethod} nu este suportată.");
            }
        }
    }
} 