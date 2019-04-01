using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2
{
    class Account
    {
        private static int numberOfAcount = 1;
        private readonly int accountNumber;
        private readonly Customer accountOwner;
        private int maxMinusAllowed;
        public int AccountNumber
        {
            get { return accountNumber; }
        }
        public int Balance { get; set; }
        public Customer AccountOwner
        {
            get { return this.accountOwner; }
        }
        public int MaxMinusAllowed
        {
            get { return maxMinusAllowed; }

        }
        public int MonthlyIncome { get; set; }
       
        public Account(Customer customer, int monthlyincome)
        {
            accountOwner = customer;
            MonthlyIncome = monthlyincome;
            maxMinusAllowed= monthlyincome * 3;
            accountNumber=numberOfAcount++;
            
        }
        public void Add(int amount)
        {
            Balance += amount;
        }
        public void Substract(int amount)
        {
            Balance -= amount;
        }
        public static bool operator ==(Account a, Account b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                throw new NullReferenceException("account cant be null");
            }

            if (a.AccountNumber == b.AccountNumber)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Account a, Account b)
        {
            return !(a.AccountNumber == b.AccountNumber);
        }
        public static Account operator +(Account a, Account b)
        {
            Account c = new Account(new Customer(a.AccountOwner.CustomerID, a.AccountOwner.Name, a.AccountOwner.PhNumber), a.MonthlyIncome + b.MonthlyIncome);
            c.Add(a.Balance + b.Balance);
            return c;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            Account account = obj as Account;
            return this.AccountNumber == account.AccountNumber;
        }

        public override int GetHashCode()
        {
            return this.AccountNumber;
        }
        public static Account operator +(Account account, int amount)
        {
            account.Balance += amount;
            return account;
        }
        public static Account operator -(Account account, int amount)
        {
            account.Balance -= amount;
            return account;
        }

        public override string ToString()
        {
            return $"number of acccounts : {numberOfAcount} inside account info: accountNumber: { AccountNumber} accountOwner: {AccountOwner} maxMinusAllowed: {MaxMinusAllowed} Balance: {Balance} MonthlyIncome: {MonthlyIncome}";

        }
    }
}
