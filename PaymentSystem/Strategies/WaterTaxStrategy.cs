using PaymentSystem.Models;

namespace PaymentSystem.Strategies
{
    public class WaterTaxStrategy : ITaxStrategy
    {
        public decimal CalculTaxa(Invoice factura)
        {
            return factura.Amount * 0.10m;
        }
    }
}
