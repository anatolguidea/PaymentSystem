namespace PaymentSystem.Commands
{
    public class PaymentInvoker
    {
        private readonly List<ICommand> _commands = new();

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void ExecuteAll()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }
    }
}
