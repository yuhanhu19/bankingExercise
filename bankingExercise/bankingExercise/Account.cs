using System;
using System.Collections.Generic;
using System.Linq;

namespace bankingExercise
{
    public class Account
    {
        public IList<TransactionRec> accountTransactionsList = new List<TransactionRec>();

        public void Deposit(int amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Deposit amount must be greater than 0");
            }
            var newRec = CreateTransactionRec(amount);
            accountTransactionsList.Add(newRec);
        }

        private TransactionRec CreateTransactionRec(int amount)
        {
            int balance;
            if (accountTransactionsList.Count == 0)
            {
                balance = amount;
            }
            else
            {
                balance = accountTransactionsList.Sum(transactionRec => transactionRec.Balance) + amount;
            }

            var newRec = new TransactionRec(DateTime.Today.ToString("MM/dd/yyyy"), amount, balance);
            return newRec;
        }

        public void Withdraw(int amount)
        {
        }

        public void PrintStatement()
        {
        }
    }
}