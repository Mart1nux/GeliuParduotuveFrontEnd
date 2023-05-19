namespace GeliuParduotuveFrontEnd.Models
{
    public class Order
    {
        public int CustomerId { get; set; }

        public string OrderCreateDate { get; set; }

        public string OrderStatus { get; set; }

        public Order(int customerId, string orderCreateDate, string orderStatus)
        {
            CustomerId = customerId;
            OrderCreateDate = orderCreateDate;
            OrderStatus = orderStatus;
        }
    }
}
