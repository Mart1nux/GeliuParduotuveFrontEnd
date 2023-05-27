namespace GeliuParduotuveFrontEnd.Models
{
    public class CartItem
    {
        public int CustomerId { get; set; }

        public int ItemId { get; set; }

        public int Amount { get; set; }

        public CartItem(int customerId, int itemId, int amount)
        {
            CustomerId = customerId;
            ItemId = itemId;
            Amount = amount;
        }
    }
}
