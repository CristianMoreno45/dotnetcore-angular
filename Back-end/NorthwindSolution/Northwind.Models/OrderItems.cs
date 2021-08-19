namespace Northwind.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitProce { get; set; }
        public int Quantity { get; set; }
    }
}
