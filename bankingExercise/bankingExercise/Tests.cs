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
            var ex1 = Assert.Throws<Exception>(() => account.Deposit(0));
            var ex2 = Assert.Throws<Exception>(() => account.Deposit(-2));
            
            Assert.Equal("Deposit amount must be greater than 0", ex1.Message);
            Assert.Equal("Deposit amount must be greater than 0", ex2.Message);
        }
    }
}