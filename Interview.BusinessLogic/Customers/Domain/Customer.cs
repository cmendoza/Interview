using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Interview.BusinessLogic.Customers.Domain
{
    public class Customer : Common.Entity
    {
        protected Customer()
        {
            Orders = new HashSet<Order>();
        }

        protected Customer(string firstName, string lastName) : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public virtual string FirstName { get; protected set; }
        public virtual string LastName  { get; protected set; }

        public virtual ICollection<Order> Orders { get; set; }

        public static Result<Customer> Create(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) return Result.Failure<Customer>("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName)) return Result.Failure<Customer>("Last name is required.");

            return Result.Success(new Customer(firstName, lastName));
        }

        public void UpdateProfileInfo(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentNullException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentNullException("Last name is required.");

            FirstName = firstName;
            LastName = lastName;
        }
    }
}
