
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Domain.src.Shared;

namespace Ecommerce.Domain.src.Entities.ProductAggregate
{
    public class ProductColor : BaseEntity
    {
        [Required]
        public ColorName ColorName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        // Navigation property
        public virtual Product? Product { get; set; }
    }
}