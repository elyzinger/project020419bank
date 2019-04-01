using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2
{
    class Customer
    {
        private static int numberOfCust = 1;
        private readonly int customerId;
        private readonly int customerNumber;
        public string Name { get; private set; }
        public int PhNumber { get;  }
        public int CustomerID
        {
            get { return this.customerId; }
        }
        public int CustomerNumber
        {
            get { return this.customerNumber; }
        }

        public Customer(int id, string name, int phNumber)
        {
            
            customerId = id;
            Name = name;
            PhNumber = phNumber;
            this.customerNumber = numberOfCust++;

        }
        public static bool operator ==(Customer a, Customer b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            if (a.CustomerNumber == b.CustomerNumber)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Customer a, Customer b)
        {
            return !(a.CustomerNumber == b.CustomerNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            Customer customer = obj as Customer;
            return this.CustomerNumber == customer.CustomerNumber;
        }

        public override int GetHashCode()
        {
            return this.customerNumber;
        }

        public override string ToString()
        {
            return $"customer details: {Name}  ID:{CustomerID} PHONE: {PhNumber} BANK NUMBER:{CustomerNumber}";
        }
    }
}
