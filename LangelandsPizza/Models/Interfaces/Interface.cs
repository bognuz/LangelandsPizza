﻿namespace LangelandsPizza.Models.Interfaces
{
    public interface IAllOrders
    {
        public void CreateAndStoreOrder(Order.Order order);
        public List<Order.Order> GetOrders();
    }
}
