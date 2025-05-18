using PaymentSystem.Models;

namespace PaymentSystem.Decorators
{
    public class LoggingPaymentProcessor : IPaymentProcessor
    {
        private readonly IPaymentProcessor _wrapped;

        public LoggingPaymentProcessor(IPaymentProcessor wrapped)
        {
            _wrapped = wrapped;
        }

        public bool ProcessPayment(decimal amount, string method)
        {
            Console.WriteLine($"[LOG] Încep plată: {amount} MDL prin {method}");
            var result = _wrapped.ProcessPayment(amount, method);
            Console.WriteLine("[LOG] Plata a fost procesată " + (result ? "cu succes." : "cu eroare!"));
            return result;
        }

        public string GetPaymentMethodName()
        {
            return _wrapped.GetPaymentMethodName();
        }
    }
}
