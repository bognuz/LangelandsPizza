namespace LangelandsPizza.Models.Interfaces
{
    public interface IAllOrders
    {
        public void CreateAndStoreOrder(Order.Order order);
        public List<Order.Order> GetNotCompletedOrders();

        public List<Order.Order> GetCompletedOrders();

        public void MarkOrderAsComplete(int orderID);
    }
}
