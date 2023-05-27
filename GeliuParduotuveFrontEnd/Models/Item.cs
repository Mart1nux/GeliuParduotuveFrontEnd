namespace GeliuParduotuveFrontEnd.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int Amount { get; set; }

        public int SellerId { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public Item(int id, string name, int amount, int sellerId, decimal price, string description, string image)
        {
            ID = id;
            Name = name;
            Amount = amount;
            SellerId = sellerId;
            Price = price;
            Description = description;
            Image = image;
        }

        public Item()
        {
            Name = "Not known";
            Amount = 0;
            SellerId = 0;
            Price = 0;
            Image = "https://media.cloudidd.com/media/pro-mediaprint/478567.jpg";
            Description = "No description";
        }
    }
}
