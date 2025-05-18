using PaymentSystem.Models;

namespace PaymentSystem.Strategies
{
    public class ElectricityTaxStrategy : ITaxStrategy
    {
        public decimal CalculTaxa(Invoice factura)
        {
            return factura.Amount * 0.20m;
        }
    }
}
