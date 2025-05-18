using PaymentSystem.Models;

namespace PaymentSystem.Validators
{
    public abstract class PaymentValidator
    {
        protected PaymentValidator _next;

        public void SetNext(PaymentValidator next)
        {
            _next = next;
        }

        public abstract bool Validate(PaymentRequest request);
    }
}
