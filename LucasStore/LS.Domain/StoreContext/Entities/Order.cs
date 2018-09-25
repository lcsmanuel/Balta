using System;
using System.Linq;
using LS.Shared.Entities;
using System.Collections.Generic;
using LS.Domain.StoreContext.Enums;

namespace LS.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque");

            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }

        public void Place()
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0, 8).ToUpper();

            if (_items.Count == 0)
                AddNotification("Order", "Pedido sem items");
        }

        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        public void Ship()
        {
            // A cada 5 produtos é uma entrega
            var deliveries = new List<Delivery>();
            var count = 1;

            // Quebra as entregas
            foreach(var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            // Envia todas as entregas
            deliveries.ForEach(x => x.Ship());
            
            // Adiciona as entregas ao pedido
            deliveries.ForEach(x => _deliveries.Add(x));

        }

        public void Cancel()
        {

            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
            
        }
    }
}