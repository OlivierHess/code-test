using CodeTest.Domain.Interfaces;

namespace CodeTest.Domain.Areas.Products.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}