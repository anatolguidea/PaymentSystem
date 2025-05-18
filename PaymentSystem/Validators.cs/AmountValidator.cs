using PaymentSystem.Models;

namespace PaymentSystem.Validators
{
    public class AmountValidator : PaymentValidator
    {
        public override bool Validate(PaymentRequest request)
        {
            if (request.Amount <= 0)
            {
                Console.WriteLine("[Eroare] Suma trebuie s? fie mai mare decât 0.");
                return false;
            }

            return _next?.Validate(request) ?? true;
        }
    }
}
