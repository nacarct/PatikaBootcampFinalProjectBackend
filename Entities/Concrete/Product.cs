using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Product:Entity
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}