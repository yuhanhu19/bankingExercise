using System;
using System.Collections.Generic;
using System.Linq;

namespace bankingExercise
{
    public class Account
    {
        public readonly IList<TransactionRec> AccountTransactionsList = new List<TransactionRec>();

        public void Deposit(int amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Deposit amount must be greater than 0");
            }

            var newRec = CreateDepositTransactionRec(amount);
            AccountTransactionsList.Add(newRec);
        }

        public void Withdraw(int amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Withdraw amount must be greater than 0");
            }

            if (AccountTransactionsList.Count == 0 ||
                AccountTransactionsList.Sum(transactionRec => transactionRec.Balance) < amount)
            {
                throw new Exception("Account balance insufficient to withdraw");
            }
            var newRec = CreateWithdrawTransactionRec(amount);
            AccountTransactionsList.Add(newRec);
        }

        private TransactionRec CreateWithdrawTransactionRec(int amount)
        {
            var currentBalance = AccountTransactionsList.Sum(transactionRec => transactionRec.Balance);
            return new TransactionRec(DateTime.Today.ToString("MM/dd/yyyy"), amount, currentBalance - amount);
        }

        public void PrintStatement()
        {
        }

        private TransactionRec CreateDepositTransactionRec(int amount)
        {
            int balance;
            if (AccountTransactionsList.Count == 0)
            {
                balance = amount;
            }
            else
            {
                balance = AccountTransactionsList.Sum(transactionRec => transactionRec.Balance) + amount;
            }

            var newRec = new TransactionRec(DateTime.Today.ToString("MM/dd/yyyy"), amount, balance);
            return newRec;
        }
    }
}