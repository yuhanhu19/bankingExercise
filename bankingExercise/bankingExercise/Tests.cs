using System;
using System.Linq;
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
        public void ShouldDepositFirstRecordSuccessGivenAbove0Amount()
        {
            var account = new Account();
            var transactionRecStored = new TransactionRec(DateTime.Today.ToString("MM/dd/yyyy"), 100, 100);

            account.Deposit(100);
            var recordCount = account.accountTransactionsList.Count;
            var transactionRecord = account.accountTransactionsList[0];

            Assert.Equal(1, recordCount);
            Assert.Equal(transactionRecStored.Date, transactionRecord.Date);
            Assert.Equal(transactionRecStored.Amount, transactionRecord.Amount);
            Assert.Equal(transactionRecStored.Balance, transactionRecord.Balance);
        }

        [Fact]
        public void ShouldDepositConsecutiveRecordsSuccessGivenAbove0Amount()
        {
            var account = new Account();
            
            account.Deposit(100);
            account.Deposit(2);
            var recordCount = account.accountTransactionsList.Count;

            Assert.Equal(2, recordCount);
            Assert.True(account.accountTransactionsList.Any(transactionRec => transactionRec.Amount == 100));
            Assert.True(account.accountTransactionsList.Any(transactionRec => transactionRec.Balance == 102));

        }
    }
}