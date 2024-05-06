namespace Command
{
    public class CompositeBankAccount
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

    public class CompositeBankAccountCommand : List<CompositeBankAccountCommand>, ICompositeCommand
    {

        private CompositeBankAccount account;

        public enum Action
        {
            Deposit, Withdraw
        }

        private Action action;
        private int amount;
        private bool succeeded;

        public CompositeBankAccountCommand(CompositeBankAccount account, Action action, int amount)
        {
            this.account = account;
            this.action = action;
            this.amount = amount;
        }

        public CompositeBankAccountCommand()
        {
        }

        public CompositeBankAccountCommand(IEnumerable<CompositeBankAccountCommand> collection)
            : base(collection)
        {
        }

        public virtual void Call()
        {
            ForEach(cmd => cmd.Call());
        }

        public virtual void Undo()
        {
            foreach (var cmd in ((IEnumerable<CompositeBankAccountCommand>)this).Reverse())
            {
                if (cmd.Success) cmd.Undo();
            }
        }

        public virtual bool Success
        {
            get { return this.All(cmd => cmd.Success); }
            set { foreach (var cmd in this) cmd.Success = value; }
        }
    }

    public interface ICompositeCommand
    {
        void Call();
        void Undo();
        bool Success { get; set; }
    }

    public class MoneyTransferCommand : CompositeBankAccountCommand
    {
        public MoneyTransferCommand(CompositeBankAccount from, CompositeBankAccount to, int amount)
        {
            AddRange(new[]
            {
                new CompositeBankAccountCommand(from, Action.Withdraw, amount),
                new CompositeBankAccountCommand(from, Action.Deposit, amount)
            });

        }
        public override void Call()
        {
            CompositeBankAccountCommand last = null;
            foreach (var cmd in this)
            {
                if (last == null || last.Success)
                {
                    cmd.Call();
                    last = cmd;
                }
                else
                {
                    cmd.Undo();
                    break;
                }
            }
        }
    }

    public class Exec
    {
        public static void Print()
        {
            var from = new CompositeBankAccount();
            from.Deposit(100);
            var to = new CompositeBankAccount();
            var mtc = new MoneyTransferCommand(from, to, 100);
            mtc.Call();
            Console.WriteLine(from);
            Console.WriteLine(to);
            mtc.Undo();
            Console.WriteLine(from);
            Console.WriteLine(to);
        }
    }
}