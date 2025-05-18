using PaymentSystem.Models;

namespace PaymentSystem.Strategies
{
    public interface ITaxStrategy
    {
        decimal CalculTaxa(Invoice factura);
    }
}
