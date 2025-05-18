using System;

namespace PaymentSystem.Factories

{
    public class InvoiceFactory
    {
        public Invoice CreateInvoice(string serviceType, decimal previousReading, decimal currentReading, decimal rate)
        {
            return serviceType.ToUpper() switch
            {
                "ELECTRICITY" => new ElectricityInvoice(previousReading, currentReading, rate),
                "WATER" => new WaterInvoice(previousReading, currentReading, rate),
                _ => throw new ArgumentException($"Serviciul {serviceType} nu este suportat.")
            };
        }
    }
} 