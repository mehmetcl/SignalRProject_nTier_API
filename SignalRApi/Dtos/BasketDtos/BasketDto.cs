namespace SignalRApi.Dtos.BasketDtos
{
    public class BasketDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
    }
}
