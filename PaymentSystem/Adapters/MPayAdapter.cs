using System;
using PaymentSystem.Services;

namespace PaymentSystem
{
    public class MPayAdapter : IPaymentProcessor
    {
        private readonly MPayService _mpayService;

        public MPayAdapter(MPayService mpayService)
        {
            _mpayService = mpayService;
        }

        public bool ProcessPayment(decimal amount, string currency)
        {
            return _mpayService.MakePayment(amount, currency);
        }

        public string GetPaymentMethodName()
        {
            return _mpayService.GetServiceName();
        }
    }
} 