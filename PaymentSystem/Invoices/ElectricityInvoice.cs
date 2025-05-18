using System;

namespace PaymentSystem
{
    public class ElectricityInvoice : Invoice
    {
        public decimal PreviousReading { get; set; }
        public decimal CurrentReading { get; set; }
        public decimal RatePerKWh { get; set; }

        public ElectricityInvoice(decimal previousReading, decimal currentReading, decimal ratePerKWh)
        {
            PreviousReading = previousReading;
            CurrentReading = currentReading;
            RatePerKWh = ratePerKWh;
            Amount = CalculateAmount();
            Currency = "MDL";
        }

        protected override string GenerateInvoiceNumber()
        {
            return $"EL-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";
        }

        public override void GenerateInvoice()
        {
            Console.WriteLine("\n=== Factură Electricitate ===");
            Console.WriteLine($"Număr Factură: {InvoiceNumber}");
            Console.WriteLine($"Data Emiterii: {IssueDate:dd.MM.yyyy}");
            Console.WriteLine($"Citire Anterioară: {PreviousReading} kWh");
            Console.WriteLine($"Citire Curentă: {CurrentReading} kWh");
            Console.WriteLine($"Consum: {CurrentReading - PreviousReading} kWh");
            Console.WriteLine($"Rată per kWh: {RatePerKWh} MDL");
            Console.WriteLine($"Sumă Totală: {Amount} {Currency}");
            Console.WriteLine("===========================");
        }

        private decimal CalculateAmount()
        {
            return (CurrentReading - PreviousReading) * RatePerKWh;
        }

        public override string GetServiceType()
        {
            return "Electricitate";
        }
    }
} 