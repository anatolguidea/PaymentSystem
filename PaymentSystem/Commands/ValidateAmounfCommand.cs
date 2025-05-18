using PaymentSystem.Models;
using System;

namespace PaymentSystem.Commands
{
    public class ValidateAmountCommand : ICommand
    {
        private readonly PaymentRequest _request;

        public ValidateAmountCommand(PaymentRequest request)
        {
            _request = request;
        }

        public void Execute()
        {
            if (_request.Amount <= 0)
                throw new Exception("Suma introdus? este invalid?.");
        }
    }
}
