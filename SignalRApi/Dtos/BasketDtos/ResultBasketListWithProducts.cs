namespace SignalRApi.Dtos.BasketDtos
{
    public class ResultBasketListWithProducts
    {
        public int Id { get; set; }

        public int MenuTableID { get; set; }

        public decimal Count { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal TotalPrice { get; set;}

        public decimal Price { get; set; }
    }
}
