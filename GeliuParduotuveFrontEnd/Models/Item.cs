namespace GeliuParduotuveFrontEnd.Models
{
    public class Item
    {
        public string Name { get; set; }

        public int Amount { get; set; }

        public int SellerId { get; set; }

        public decimal Price { get; set; }

        public Item(string name, int amount, int sellerId, decimal price)
        {
            Name = name;
            Amount = amount;
            SellerId = sellerId;
            Price = price;
        }
    }
}
