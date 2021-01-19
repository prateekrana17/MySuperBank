using System;
using System.Collections.Generic;
using System.Text;

namespace MySuperBank
{
    class BankAccount
    {
        public string account_number { get; }
        public string owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var t in transaction)
                {
                    balance += t.Amount;
                }

                return balance;
            }
        }
        private List<Transaction> transaction = new List<Transaction>();



        public BankAccount(string name, decimal initialbal)
        {
            owner = name;
            Random r = new Random();
            double suffix = r.Next(100000000);
            string prefix = "MSB00";
            account_number = prefix + suffix.ToString();
            MakeDeposit(initialbal, DateTime.Now, "Initial balance");
        }


        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            transaction.Add(deposit);
            Console.WriteLine($"{amount} Deposit Made");
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            transaction.Add(withdrawal);
            Console.WriteLine($"{amount} Withdrawal Successful");
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in transaction)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }
    }
}
