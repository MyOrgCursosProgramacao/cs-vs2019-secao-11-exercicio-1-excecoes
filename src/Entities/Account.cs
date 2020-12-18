﻿using src.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace src.Entities
{
    class Account
    {
        public int Number { get; private set; }
        public string Name { get; private set; }
        public double Balance { get; private set; }
        public double WithdrawLimit { get; private set; }

        public Account()
        {
        }

        public Account(int number, string name, double withdrawLimit)
        {
            Number = number;
            Name = name;
            WithdrawLimit = withdrawLimit;
        }

        public Account(int number, string name, double balance, double withdrawLimit)
        {
            Number = number;
            Name = name;
            Deposit (balance);
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit (double amount)
        {
            if (amount < 0)
            {
                throw new DomainException("A quantia de depósito não pode ser um valor negativo");
            }

            Balance += amount;
        }

        public void Withdraw (double amount)
        {
            if (amount < 0)
            {
                throw new DomainException("A quantia de saque não pode ser um valor negativo");
            }
            if (amount > WithdrawLimit)
            {
                throw new DomainException("O valor ultrapassa o limite de saque de $"
                     + WithdrawLimit.ToString("F2", CultureInfo.InvariantCulture));
            }
            if (amount > Balance)
            {
                throw new DomainException("Saldo insuficiente ($"
                    + Balance.ToString("F2", CultureInfo.InvariantCulture));
            }

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
