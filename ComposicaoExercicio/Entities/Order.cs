using System;
using System.Collections.Generic;
using System.Text;
using ComposicaoExercicio.Entities.Enums;

namespace ComposicaoExercicio.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }
        public void AddItem(OrderItem items)
        {
            Items.Add(items);
        }
        public void RemoveItem(OrderItem items)
        {
            Items.Remove(items);
        }
        public double Total()
        {
            double sum = 0.0;
            foreach (OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name + " ");
            sb.Append(Client.BirthDate.ToString("dd/MM/yyyy"));
            sb.AppendLine(" - " + Client.Email);
            sb.AppendLine("Order items:");
            foreach (OrderItem x in Items)
            {
                sb.Append(x.Product.Name + ", Quantity: ");
                sb.Append(x.Quantity + ", ");
                sb.AppendLine("Subtotal: " + x.SubTotal().ToString("F2"));
            }
            sb.AppendLine("Total price: " + Total());
            return sb.ToString();
        }
    }
}