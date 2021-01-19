using System;
using System.Collections.Generic;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account1 = new BankAccount("Prateek Rana",500);
            Console.WriteLine($"Account-{account1.account_number} created for {account1.owner}");
            Console.WriteLine($"Account balance is GBP: {account1.Balance}");
            account1.MakeDeposit(1500, DateTime.Now, "Rent");
            account1.MakeWithdrawal(300, DateTime.Now, "Food");
            Console.WriteLine($"Account balance is GBP: {account1.Balance}");
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine(account1.GetAccountHistory());
        }
    }
}
