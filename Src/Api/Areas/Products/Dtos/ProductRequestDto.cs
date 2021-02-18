using System.ComponentModel.DataAnnotations;

namespace CodeTest.Api.Areas.Products.Dtos
{
    public class ProductRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required, Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}