using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank laumi = new Bank("laumi", "petach tikva", 23);
            List<Customer> customers = new List<Customer>();
            Customer a , b, c;
            laumi.AddNewCustomer(a = new Customer(1234, "guy", 2254));
            laumi.AddNewCustomer(b = new Customer(3456, "gil", 3));
            laumi.AddNewCustomer(c = new Customer(3123, "dani", 2754));


          
       
            Console.WriteLine(laumi.GetCustomerByID(1234));
            Console.WriteLine(laumi.GetCustomerByNumber(2));
            Console.WriteLine(laumi);
            laumi.PrintAllCustomers();
            for (int i = 1; i <= laumi.NumOfCust; i++)
            {
                Customer customer = laumi.GetCustomerByNumber(i);
                laumi.OpenNewAccount(new Account(customer, 20000), customer);
                laumi.OpenNewAccount(new Account(customer, 30000), customer);
                laumi.OpenNewAccount(new Account(customer, 40000), customer);
            }
            laumi.OpenNewAccount(new Account(c, 40000), c);
            laumi.OpenNewAccount(new Account(c, 20000), c);

            for (int i = 1; i <= laumi.NumOfCust; i++)
            {
                Customer customer = laumi.GetCustomerByNumber(i);

                foreach (Account account in laumi.GetAccountByCustomer(customer))
                {
                    laumi.Deposit(account, 10000);
                }
            }
            laumi.GetAccountsByNumber(2).Add(2000);
            laumi.GetAccountsByNumber(5).Substract(3000);
            laumi.Withdraw(laumi.GetAccountsByNumber(6), 5000);

            for (int i = 1; i <= laumi.NumOfCust; i++)
            {
                Customer customer = laumi.GetCustomerByNumber(i);
                Console.WriteLine($"Account List of customer : {customer.Name}");
                foreach (Account account in laumi.GetAccountByCustomer(customer))
                {
                    Console.WriteLine(account);
                }
            }
            for (int i = 1; i <= laumi.NumOfCust; i++)
            {
                Customer customer = laumi.GetCustomerByNumber(i);
                Console.WriteLine($"Total balance of customer : {customer.Name}");
                Console.WriteLine(laumi.GetCustomerTotalBalance(customer));
            }
            laumi.ChargeAnnualCommission(1.5f);

            for (int i = 1; i <= laumi.NumOfCust; i++)
            {
                Customer customer = laumi.GetCustomerByNumber(i);
                Console.WriteLine($"Account List of customer : {customer.Name}");
                foreach (Account account in laumi.GetAccountByCustomer(customer))
                {
                    Console.WriteLine(account); 
                }
            }
            Console.WriteLine();
            laumi.GetAccountsByNumber(5).Substract(20000);
            laumi.ChargeAnnualCommission(1.5f);
            Console.ReadLine();
            for (int i = 1; i <= laumi.NumOfCust; i++)
            {
                Customer customer = laumi.GetCustomerByNumber(i);
                Console.WriteLine($"Account List of customer : {customer.Name}");
                foreach (Account account in laumi.GetAccountByCustomer(customer))
                {
                    Console.WriteLine(account); 
                }
            }
            laumi.JoinAccounts(laumi.GetAccountsByNumber(4), laumi.GetAccountsByNumber(5));
            for (int i = 1; i <= laumi.NumOfCust; i++)
            {
                Customer customer = laumi.GetCustomerByNumber(i);
                Console.WriteLine($"Account List of customer : {customer.Name}");
                foreach (Account account in laumi.GetAccountByCustomer(customer))
                {
                    Console.WriteLine(account); 
                }
            }
        }
    }
}
