using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Shared;

namespace Ecommerce.Domain.src.ProductAggregate
{
    public class ProductSize : BaseEntity
    {
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        [Required]
        public SizeValue SizeValue { get; set; }

        [Required]
        public int Quantity { get; set; }

        // Navigation property
        public virtual Product? Product { get; set; }
    }
}