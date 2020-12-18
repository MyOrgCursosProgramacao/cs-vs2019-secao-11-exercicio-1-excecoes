using System;
using System.Collections.Generic;
using System.Text;

namespace src.Entities
{
    class Account
    {
        public int Number { get; private set; }
        public string Name { get; private set; }
        public double Balance { get; private set; }

        public Account()
        {
        }

        public Account(int number, string name, double balance)
        {
            Number = number;
            Name = name;
            Balance = balance;
        }

        public void Deposit (double amount)
        {
            Balance += amount;
        }

        public void Withdraw (double amount)
        {
            Balance -= amount;
        }

        public override string ToString()
        {
            return Number
                + ", "
                + Name
                + ", $ "
                + Balance;
        }
    }
}
