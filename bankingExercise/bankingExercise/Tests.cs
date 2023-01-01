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

        [Fact]
        public void ShouldStoreTransactionSuccessWhenDepositGivenAbove0Amount()
        {
            var account = new Account();
            var transactionRecStored = new TransactionRec(DateTime.Today.ToString("MM/dd/yyyy"), 100, 100);
            
            account.Deposit(100);
            var recordCount = account.accountTransactionsTable.Count;
            var transactionRecord  = account.accountTransactionsTable[0];
            
            Assert.Equal(1, recordCount);
            Assert.Equal(transactionRecStored.Date, transactionRecord.Date);
            Assert.Equal(transactionRecStored.Amount, transactionRecord.Amount);
            Assert.Equal(transactionRecStored.Balance, transactionRecord.Balance);
        }
    }
}