using System.Linq.Expressions;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Infrastructure.src.Database;
using Ecommerce.Domain.Enums;
using Ecommerce.Infrastructure.src.Repository;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductSizeRepository : BaseRepository<ProductSize>, IProductSizeRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductSizeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductSize>> GetSizesByProductIdAsync(Guid productId)
        {
            return await _context.ProductSizes.Where(ps => ps.Product.Id == productId).ToListAsync();
        }

        public async Task<ProductSize> GetSizeByValueAsync(SizeValue size)
        {
            return await _context.ProductSizes.FirstOrDefaultAsync(ps => ps.SizeValue == size);
        }
    }
}
