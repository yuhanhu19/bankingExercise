using System;
using System.Collections.Generic;

namespace bankingExercise
{
    public class Account
    {
        private Dictionary<string, TransactionRec> accountTransactionsTable = new Dictionary<string, TransactionRec>();

        public void Deposit(int amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Deposit amount must be greater than 0");
            }
        }

        public void withdraw(int amount)
        {
        }

        public void printStatement()
        {
        }
    }
}