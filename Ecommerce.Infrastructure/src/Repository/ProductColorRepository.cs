using System.Linq.Expressions;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Entities.ProductAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.src.Repository
{
    public class ProductColorRepository : BaseRepository<ProductColor>, IProductColorRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductColorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductColor>> GetColorsByProductIdAsync(Guid productId)
        {
            return await _context.ProductColors
                .Where(pc => pc.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ProductColor> GetColorByNameAsync(string colorName)
        {
            // Use Enum.Parse or try to match enum values instead of using Equals
            if (Enum.TryParse(typeof(ColorName), colorName, true, out var colorEnum))
            {
                return await _context.ProductColors
                    .Where(pc => pc.ColorName == (ColorName)colorEnum)
                    .FirstOrDefaultAsync();
            }

            return null;
        }
    }
}
