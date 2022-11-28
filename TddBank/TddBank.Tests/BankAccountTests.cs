namespace TddBank.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void New_account_has_zero_as_balance()
        {
            var ba = new BankAccount();

            Assert.Equal(0m, ba.Balance);
        }

        [Fact]
        public void Deposit_adds_to_Balance()
        {
            var ba = new BankAccount();

            ba.Deposit(3m);
            ba.Deposit(6m);

            Assert.Equal(9m, ba.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deposit_negative_or_zero_throws_ArgumentException(decimal amount)
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Deposit(amount));
        }

        [Fact]
        public void Withdraw_subs_from_Balance()
        {
            var ba = new BankAccount();
            ba.Deposit(20);

            ba.Withdraw(12m);
            ba.Withdraw(2m);

            Assert.Equal(6m, ba.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Withdraw_negative_or_zero_throws_ArgumentException(decimal amount)
        {
            var ba = new BankAccount();
            ba.Deposit(20);

            Assert.Throws<ArgumentException>(() => ba.Withdraw(amount));
        }

        [Fact]
        public void Withdraw_below_zero_balance_throws_InvalidOperationException()
        {
            var ba = new BankAccount();
            ba.Deposit(20);

            Assert.Throws<InvalidOperationException>(() => ba.Withdraw(22m));
        }

    }
}