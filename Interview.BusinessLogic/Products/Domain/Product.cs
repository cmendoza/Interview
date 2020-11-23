using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Interview.BusinessLogic.Products.Domain
{
    public class Product : Common.Entity
    {
        protected Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        protected Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public virtual string  Name  { get; protected set; }
        public virtual decimal Price { get; protected set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public static Result<Product> Create(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name)) return Result.Failure<Product>("Name is required.");

            if (price <= 0) return Result.Failure<Product>("Price must be greater than zero.");

            return Result.Success(new Product(name, price));
        }

        public void UpdateInfo(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(Name));

            if (price <= 0) throw new ArgumentException(nameof(price));

            Name = name;
            Price = price;
        }
    }
}
