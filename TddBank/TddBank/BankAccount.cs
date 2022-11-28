namespace TddBank
{
    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Nicht 0 oder weniger");

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Nicht 0 oder weniger");
            if (amount > Balance)
                throw new InvalidOperationException("Nicht genug Geld!");

            Balance -= amount;
        }
    }
}