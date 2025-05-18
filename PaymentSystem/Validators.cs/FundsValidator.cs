using PaymentSystem.Models;

namespace PaymentSystem.Validators
{
    public class FundsValidator : PaymentValidator
    {
        public override bool Validate(PaymentRequest request)
        {
            if (!request.HasSufficientFunds)
            {
                Console.WriteLine("[Eroare] Fonduri insuficiente.");
                return false;
            }

            return _next?.Validate(request) ?? true;
        }
    }
}
