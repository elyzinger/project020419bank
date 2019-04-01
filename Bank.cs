using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2
{
    class Bank : IBank, IEnumerable
    {
        public string Name { get; }
        public string Address { get; }
        public int CustomerCount { get; }
        private List<Account> accounts;
        private List<Customer> customers;
        private Dictionary<int, Customer> _customerByID;//[customersID]
        private Dictionary<int, Customer> _customerByCustomerNumber;//[customerNumber]
        private Dictionary<int, Account> _accountByAccountNumber;//[accountNumber]
        private Dictionary<Customer, List<Account>> _accountsByCustomer;
        private int totalMoneyInBank;
        private int profits;
        public int NumOfCust
        {
            get
            {
                return customers.Count;
            }
        }
        public Bank(string name, string address, int customerCount)
        {
            Name = name;
            Address = address;
            CustomerCount = customerCount;
            _customerByID = new Dictionary<int, Customer>();
            _customerByCustomerNumber = new Dictionary<int, Customer>();
            _accountByAccountNumber = new Dictionary<int, Account>();
            _accountsByCustomer = new Dictionary<Customer, List<Account>>();
            accounts = new List<Account>();
            customers = new List<Customer>();
        }

      

        internal Customer GetCustomerByID(int customerId)
        {
            if (!_customerByID.ContainsKey(customerId))
            {
                throw new CustomerNotFoundException("customer not in the system");
            }
            return _customerByID[customerId];
        }
        internal Customer GetCustomerByNumber(int customerNumber)

        {
            if (!_customerByCustomerNumber.ContainsKey(customerNumber))
            {
                throw new CustomerNotFoundException("customer not in the system");
            }
            return _customerByCustomerNumber[customerNumber];
        }
        internal Account GetAccountsByNumber(int accountNumber)
        {
            if (!_accountByAccountNumber.ContainsKey(accountNumber))
            {
                throw new AccountNotFountExecption("account not found");
            }
            return _accountByAccountNumber[accountNumber];
        }
        internal List<Account> GetAccountByCustomer(Customer customer)
        {
            if (!_accountsByCustomer.ContainsKey(customer))
            {
                throw new AccountNotFountExecption("account not found");
            }
            return _accountsByCustomer[customer];
        }
        internal void AddNewCustomer(Customer customer)
        {
            if (customers.Contains(customer))
            {
                throw new CustomerAlreadyExistExecption("customer already in the system");
            }
            customers.Add(customer);
            _customerByID.Add(customer.CustomerID, customer);
            _customerByCustomerNumber.Add(customer.CustomerNumber, customer);
            _accountsByCustomer.Add(customer, new List<Account>());


        }
        internal void OpenNewAccount(Account account, Customer customer)
        {
            if (accounts.Contains(account))
            {
                throw new AccountAlreadyExistExecption("account already in the system");
            }
            accounts.Add(account);
            _accountByAccountNumber.Add(account.AccountNumber, account);
            _accountsByCustomer[customer].Add(account);
        }
        internal int Deposit(Account account, int amount)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotFountExecption("account not found");
            }
            account.Add(amount);
            totalMoneyInBank += amount;
            return totalMoneyInBank;

        }
        internal int Withdraw(Account account, int amount)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotFountExecption("account not found");
            }
            if (account.MaxMinusAllowed < amount)
            {
                throw new BalanceException("out of limit");
            }
            account.Substract(amount);
            totalMoneyInBank -= amount;
            return totalMoneyInBank;

        }

        internal int GetCustomerTotalBalance(Customer customer)
        {
            int sum = 0;
            if (!customers.Contains(customer))
            {
                throw new CustomerNotFoundException("customer not in the system");
            }
            foreach (Account account in _accountsByCustomer[customer])
            {
                sum += account.Balance;
            }
            return sum;
        }
        internal void CloseAccount(Account account, Customer customer)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotFountExecption("account not found");
            }
            if (!customers.Contains(customer))
            {
                throw new CustomerNotFoundException("customer not in the system");
            }
            if (!_accountsByCustomer[customer].Contains(account))
            {
                throw new AccountNotFountExecption("Account not found");
            }
            if (!_accountByAccountNumber.ContainsKey(account.AccountNumber))
            {
                throw new AccountNotFountExecption("Account not found");
            }
            _accountsByCustomer[customer].Remove(account);
            accounts.Remove(account);
            _accountByAccountNumber.Remove(account.AccountNumber);
        }
        internal void ChargeAnnualCommission(float percentage)
        {
            float commission = 0;
            foreach (Account account in accounts)
            {
                if (account.Balance > 0)
                {
                    commission = (account.Balance * percentage) / 100;
                }
                else
                {
                    commission = (2 * account.Balance * percentage) / 100;
                }
                int intcomission = Convert.ToInt32(commission);
                profits += intcomission;
                account.Balance -= intcomission;
            }

        }
        public void JoinAccounts(Account account1, Account account2)
        {
            if (!(account1.AccountOwner == account2.AccountOwner))
            {
                throw new NotSameCustomerExecption("the accounts are not join accounts");
            }
            Account newAccount = account1 + account2;
            OpenNewAccount(newAccount, newAccount.AccountOwner);
            CloseAccount(account1, account1.AccountOwner);
            CloseAccount(account2, account2.AccountOwner);
        }
        internal void PrintAllCustomers()
        {
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
        public IEnumerator GetEnumerator()
        {
            return customers.GetEnumerator();
        }

        public override string ToString()
        {
            return $"Bank : {Name} : Addres: {Address}  Number Of Customers IN The Bank : {CustomerCount}";
        }
    }
}
