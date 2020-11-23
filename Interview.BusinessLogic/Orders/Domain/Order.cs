﻿using Interview.BusinessLogic.Customers.Domain;
using Interview.BusinessLogic.Products.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview.BusinessLogic.Orders.Domain
{
    public partial class Order : Common.Entity
    {
        private readonly List<OrderItem> _orderItems;

        protected Order()
        {
            _orderItems = new List<OrderItem>();
            CreatedAt = DateTime.Now;
        }

        public Order(Customer customer) : this()
        {
            Customer = customer;
        }

        public virtual decimal  Total     { get; protected set; }
        public virtual DateTime CreatedAt { get; protected set; }

        public virtual Customer Customer { get; protected set; }
        public virtual IReadOnlyCollection<OrderItem> OrderItems => _orderItems.ToList();

        public void AddItem(Product product, int quantity)
        {
            _orderItems.Add(new OrderItem(product, quantity));
        }
    }
}
