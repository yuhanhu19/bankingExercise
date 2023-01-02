namespace bankingExercise
{
    public class TransactionRec
    {
        public string Date { get; set; }

        public int Amount { get; set; }

        public int Balance { get; set; }

        public TransactionRec(string date, int amount, int balance)
        {
            Date = date;
            Amount = amount;
            Balance = balance;
        }
    }
}