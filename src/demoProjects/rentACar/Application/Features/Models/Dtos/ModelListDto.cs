namespace Application.Features.Models.Dtos
{
    public class ModelListDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal DailyPrice { get; set; }
        public string? ImageUrl { get; set; }
    }
}
