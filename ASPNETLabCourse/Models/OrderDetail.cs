namespace ASPNETLabCourse.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ShoesId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public virtual Shoes Shoes { get; set; }
        public virtual Order Order { get; set; }
    }
}