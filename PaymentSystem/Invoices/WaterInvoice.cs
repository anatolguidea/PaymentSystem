using System;

namespace PaymentSystem
{
    public class WaterInvoice : Invoice
    {
        public decimal PreviousReading { get; set; }
        public decimal CurrentReading { get; set; }
        public decimal RatePerCubicMeter { get; set; }

        public WaterInvoice(decimal previousReading, decimal currentReading, decimal ratePerCubicMeter)
        {
            PreviousReading = previousReading;
            CurrentReading = currentReading;
            RatePerCubicMeter = ratePerCubicMeter;
            Amount = CalculateAmount();
            Currency = "MDL";
        }

        protected override string GenerateInvoiceNumber()
        {
            return $"WAT-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";
        }

        public override void GenerateInvoice()
        {
            Console.WriteLine("\n=== Factură Apă ===");
            Console.WriteLine($"Număr Factură: {InvoiceNumber}");
            Console.WriteLine($"Data Emiterii: {IssueDate:dd.MM.yyyy}");
            Console.WriteLine($"Citire Anterioară: {PreviousReading} m³");
            Console.WriteLine($"Citire Curentă: {CurrentReading} m³");
            Console.WriteLine($"Consum: {CurrentReading - PreviousReading} m³");
            Console.WriteLine($"Rată per m³: {RatePerCubicMeter} MDL");
            Console.WriteLine($"Sumă Totală: {Amount} {Currency}");
            Console.WriteLine("===================");
        }

        private decimal CalculateAmount()
        {
            return (CurrentReading - PreviousReading) * RatePerCubicMeter;
        }

        public override string GetServiceType()
        {
            return "Apă";
        }
    }
} 