using System;
using Xunit;

namespace bankingExercise
{
    public class Tests
    {
        [Fact]
        public void ShouldThrowExceptionWhenDepositGiven0OrNegativeAmount()
        {
            var account = new Account();
            var ex1 = Assert.Throws<Exception>(() => account.deposit(0));
            account.deposit(0);
            var ex2 = Assert.Throws<Exception>(() => account.deposit(-2));
            account.deposit(0);

            Assert.Equal("Deposit amount must be at least 1", ex1.Message);
            Assert.Equal("Deposit amount must be at least 1", ex2.Message);
        }
    }
}