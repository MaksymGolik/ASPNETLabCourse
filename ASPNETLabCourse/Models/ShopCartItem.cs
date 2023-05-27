namespace ASPNETLabCourse.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public string ShopCartId { get; set; }
        public Shoes Shoes { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}