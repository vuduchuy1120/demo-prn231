namespace Demo_API_Empty.DTO
{
    public class CategoryResponse
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public List<ProductResponse> Products { get; set; }
    }
}
