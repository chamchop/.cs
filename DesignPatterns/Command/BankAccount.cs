namespace Command
{
    public class BankAccount
    {
        private int balance;
        private int overdraftLimit = -500;

        public void Deposit(int amount)
        {
            balance += amount;
            Console.WriteLine(amount);
        }

        public bool Withdraw(int amount)
        {
            if (balance - amount >= overdraftLimit)
            {
                balance -= amount;
                Console.WriteLine(balance);
                return true;
            }
            return false;
        }
    }

    interface ICommand
    {
        void Call();
        void Undo();
    }

    public class BankAccountCommand : ICommand
    {
        private BankAccount account;

        public enum Action
        {
            Deposit, Withdraw
        }

        private Action action;
        private int amount;
        private bool succeeded;

        public BankAccountCommand(BankAccount account, Action action, int amount)
        {
            this.account = account;
            this.action = action;
            this.amount = amount;
        }

        public void Call()
        {
            switch (action)
            {
                case Action.Deposit: account.Deposit(amount); succeeded = true; break;
                case Action.Withdraw: succeeded = account.Withdraw(amount); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        public void Undo()
        {
            if (!succeeded) return;
            switch (action)
            {
                case Action.Deposit: account.Withdraw(amount); break;
                case Action.Withdraw: account.Deposit(amount); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }

    public class Exe
    {
        public static void Print()
        {
            var account = new BankAccount();
            var commands = new List<BankAccountCommand>
            {
                new BankAccountCommand(account, BankAccountCommand.Action.Deposit, 100),
                new BankAccountCommand(account, BankAccountCommand.Action.Deposit, 50)
            };
            foreach (var command in commands) command.Call();
            foreach (var command in Enumerable.Reverse(commands)) command.Undo();
        }
    }
}
