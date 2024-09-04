using Ecommerce.Domain.src.Entities.OrderAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.OrderService;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.OrderItemService
{
    public class OrderItemManagement : BaseService<OrderItem, OrderItemReadDto, OrderItemCreateDto, OrderItemUpdateDto>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderItemManagement(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, IProductRepository productRepository) : base(orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        /* public async Task<OrderItem> CreateAsync(OrderItemCreateDto createDto)
        {
            try
            {
                if (createDto == null)
                    throw new ArgumentException("Order data is required.");

                if (createDto.OrderId == Guid.Empty)
                    throw new ArgumentException("Order ID is required.");

                if (createDto.ProductId == Guid.Empty)
                    throw new ArgumentException("Product ID is required.");

                var order = await _orderRepository.GetAsync(o => o.Id == createDto.OrderId);
                if (order == null)
                    throw new ArgumentException("Invalid Order");

                var product = await _productRepository.GetAsync(ad => ad.Id == createDto.ProductId);
                if (product == null)
                    throw new ArgumentException("Invalid Product.");

                var orderItem = createDto.CreateEntity();
                return await _orderItemRepository.CreateAsync(orderItem);

            }
            catch
            {
                throw new Exception("Error creating order item!");
            }
        }

        public async Task<bool> UpdateAsync(Guid id, OrderItemUpdateDto updateDto)
        {
            try
            {
                var existingOrderItem = await _orderItemRepository.GetAsync(oi => oi.Id == id);

                if (existingOrderItem == null)
                    throw new ArgumentException("Order not found.");

                if (updateDto == null)
                    throw new ArgumentException("Order data is required.");

                if (updateDto.OrderId == Guid.Empty)
                    throw new ArgumentException("Order ID is required.");

                if (updateDto.ProductId == Guid.Empty)
                    throw new ArgumentException("Product ID is required.");

                var order = await _orderRepository.GetAsync(o => o.Id == updateDto.OrderId);
                if (order == null)
                    throw new ArgumentException("Invalid Order");

                var product = await _productRepository.GetAsync(ad => ad.Id == updateDto.ProductId);
                if (product == null)
                    throw new ArgumentException("Invalid Product.");

                var orderItemUpdateDto = new OrderItemUpdateDto();
                var orderItemToUpdate = orderItemUpdateDto.UpdateEntity(existingOrderItem);

                return await _orderItemRepository.UpdateByIdAsync(orderItemToUpdate);
            }
            catch
            {
                throw new Exception("Error Updating Order item!.");
            }
        } */


        public async Task<IEnumerable<OrderItemReadDto>> GetOrderItemsByOrderIdAsync(Guid orderId)
        {
            try
            {
                var order = await _orderRepository.GetAsync(o => o.Id == orderId);
                if (order == null)
                    throw new ArgumentException("Order not found.");

                var orderitems = await _orderItemRepository.GetOrderItemsByOrderIdAsync(orderId);
                var orderItemDtos = orderitems.Select(item =>
                {
                    var dto = new OrderItemReadDto();
                    dto.FromEntity(item);
                    return dto;
                });

                return orderItemDtos;

            }
            catch
            {
                throw new Exception("Error Retrieving Order items!.");
            }
        }

        public async Task<IEnumerable<OrderItemReadDto>> GetOrderItemsByProductIdAsync(Guid productId)
        {
            try
            {
                var product = await _productRepository.GetAsync(ad => ad.Id == productId);
                if (product == null)
                    throw new ArgumentException("Invalid Product.");

                var orderitems = await _orderItemRepository.GetOrderItemsByProductIdAsync(productId);
                var orderItemDtos = orderitems.Select(item =>
                {
                    var dto = new OrderItemReadDto();
                    dto.FromEntity(item);
                    return dto;
                });

                return orderItemDtos;
            }
            catch
            {
                throw new Exception("Error Retrieving Order items!.");
            }
        }

        public async Task<int> GetTotalQuantityByOrderIdAsync(Guid orderId)
        {
            try
            {
                var order = await _orderRepository.GetAsync(o => o.Id == orderId);
                if (order == null)
                    throw new ArgumentException("Order not found.");

                var orderItems = await _orderItemRepository.GetOrderItemsByOrderIdAsync(orderId);
                return orderItems.Sum(item => item.Quantity);
            }
            catch
            {
                throw new Exception("Error Retrieving total quantity!.");
            }
        }
    }
}