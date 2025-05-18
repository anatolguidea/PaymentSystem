using System;
using PaymentSystem.Services;

namespace PaymentSystem
{
    public class MAIBAdapter : IPaymentProcessor
    {
        private readonly MAIBService _maibService;

        public MAIBAdapter(MAIBService maibService)
        {
            _maibService = maibService;
        }

        public bool ProcessPayment(decimal amount, string currency)
        {
            return _maibService.ExecutePayment(amount, currency);
        }

        public string GetPaymentMethodName()
        {
            return _maibService.GetBankName();
        }
    }
} 