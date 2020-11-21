using Interview.BusinessLogic.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.BusinessLogic.Customers.Domain
{
    public class Customer : Entity
    {
        protected Customer()
        {

        }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName  { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
