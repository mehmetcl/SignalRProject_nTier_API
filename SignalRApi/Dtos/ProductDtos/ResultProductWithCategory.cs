namespace SignalRApi.Dtos.ProductDtos
{
    public class ResultProductWithCategory
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public bool Status { get; set; }

        public decimal Price { get; set; }
    }
}
