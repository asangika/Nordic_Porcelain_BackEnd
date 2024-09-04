using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductService
{
    public class ProductManagement : BaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>, IProductManagement
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public ProductManagement(IProductRepository productRepository, ICategoryRepository categoryRepository, IOrderItemRepository orderItemRepository) : base(productRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _orderItemRepository = orderItemRepository;
        }
        /* public async Task<Product> CreateAsync(ProductCreateDto productCreateDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productCreateDto.Title))
                    throw new ArgumentException("Product title is required.");

                if (string.IsNullOrWhiteSpace(productCreateDto.Description))
                    throw new ArgumentException("Product description is required.");

                if (productCreateDto.Price <= 0)
                    throw new ArgumentException("Product price must be positive.");

                if (productCreateDto.Stock < 0)
                    throw new ArgumentException("Product stock cannot be negative.");

                var category = await _categoryRepository.GetAsync(c => c.Id == productCreateDto.CategoryId);
                if (category == null)
                    throw new ArgumentException("Invalid category.");

                var product = productCreateDto.CreateEntity();

                return await _productRepository.CreateAsync(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating product!");
            }

        } */

        /* public async Task<bool> UpdateAsync(Guid productId, ProductUpdateDto productUpdateDto)
        {
            try
            {
                var existingProduct = await _productRepository.GetAsync(p => p.Id == productId);

                if (existingProduct == null)
                    throw new ArgumentException("Product not found.");

                if (string.IsNullOrWhiteSpace(productUpdateDto.Title))
                    throw new ArgumentException("Product title is required.");

                if (string.IsNullOrWhiteSpace(productUpdateDto.Description))
                    throw new ArgumentException("Product description is required.");

                if (productUpdateDto.Price <= 0)
                    throw new ArgumentException("Product price must be positive.");

                if (productUpdateDto.Stock < 0)
                    throw new ArgumentException("Product stock cannot be negative.");

                var category = await _categoryRepository.GetAsync(c => c.Id == productUpdateDto.CategoryId);
                if (category == null)
                    throw new ArgumentException("Invalid category.");

                var productToUpdate = productUpdateDto.UpdateEntity(existingProduct);

                return await _productRepository.UpdateByIdAsync(productToUpdate);
            }
            catch (Exception)
            {
                throw new Exception("Error Updating Product!.");
            }

        } */

        public async Task<IEnumerable<ProductReadDto>> GetProductsByCategoryAsync(Guid categoryId)
        {
            try
            {
                var category = await _categoryRepository.GetAsync(c => c.Id == categoryId);
                if (category == null)
                    throw new ArgumentException("Invalid category.");

                var products = await _productRepository.GetProductsByCategoryAsync(categoryId);
                var productDtos = products.Select(product =>
                {
                    var dto = new ProductReadDto();
                    dto.FromEntity(product);
                    return dto;
                });

                return productDtos;
            }
            catch (Exception)
            {
                throw new Exception("Error Retrieving Products!.");
            }

        }

        public async Task<IEnumerable<ProductReadDto>> SearchProductsByTitleAsync(string title)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(title))
                    throw new ArgumentException("Product title is required.");

                var products = await _productRepository.SearchProductsByTitleAsync(title);
                var productDtos = products.Select(product =>
                {
                    var dto = new ProductReadDto();
                    dto.FromEntity(product);
                    return dto;
                });

                return productDtos;
            }
            catch (Exception)
            {
                throw new Exception("Error Retrieving Products!.");
            }
        }

        public async Task<IEnumerable<ProductReadDto>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            try
            {
                if (minPrice < 0)
                    throw new ArgumentException("Minimum price cannot be negative.", nameof(minPrice));

                if (maxPrice < 0)
                    throw new ArgumentException("Maximum price cannot be negative.", nameof(maxPrice));

                if (minPrice > maxPrice)
                    throw new ArgumentException("Minimum price cannot be greater than maximum price.");

                var products = await _productRepository.GetProductsByPriceRangeAsync(minPrice, maxPrice);
                var productDtos = products.Select(product =>
                {
                    var dto = new ProductReadDto();
                    dto.FromEntity(product);
                    return dto;
                });

                return productDtos;
            }
            catch (Exception)
            {
                throw new Exception("Error Retrieving Products!.");
            }
        }

        public async Task<IEnumerable<ProductReadDto>> GetTopSellingProductsAsync(int count)
        {
            try
            {
                if (count <= 0)
                    throw new ArgumentException("Count must be a positive integer.", nameof(count));

                var products = await _productRepository.GetTopSellingProductsAsync(count);
                var productDtos = products.Select(product =>
                {
                    var dto = new ProductReadDto();
                    dto.FromEntity(product);
                    return dto;
                });

                return productDtos;
            }
            catch (Exception)
            {
                throw new Exception("Error Retrieving Products!.");
            }
        }

        public async Task<IEnumerable<Product>> GetInStockProductsAsync()
        {
            try
            {
                return await _productRepository.GetInStockProductsAsync();

            }
            catch (Exception)
            {
                throw new Exception("Error Retrieving Stock count!.");
            }
        }
    }
}