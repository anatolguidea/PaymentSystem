using PaymentSystem.Models;
using System;

namespace PaymentSystem.Commands
{
    public class ValidateFundsCommand : ICommand
    {
        private readonly PaymentRequest _request;

        public ValidateFundsCommand(PaymentRequest request)
        {
            _request = request;
        }

        public void Execute()
        {
            if (!_request.HasSufficientFunds)
                throw new Exception("Fonduri insuficiente.");
        }
    }
}
