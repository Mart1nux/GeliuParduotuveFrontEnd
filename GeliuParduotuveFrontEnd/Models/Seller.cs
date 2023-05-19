namespace GeliuParduotuveFrontEnd.Models
{
    public class Seller
    {
        public string SellerCode { get; set; }

        public int CustomerId { get; set; }

        public Seller(string sellerCode, int customerId)
        {
            SellerCode = sellerCode;
            CustomerId = customerId;
        }
    }
}
