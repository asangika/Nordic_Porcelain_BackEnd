using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Entities.OrderAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.OrderService
{
    public class OrderManagement : BaseService<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;

        public OrderManagement(IOrderRepository orderRepository, IUserRepository userRepository, IAddressRepository addressRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<OrderReadDto>> GetOrdersByUserIdAsync(Guid userId)
        {
            try
            {
                var user = await _userRepository.GetAsync(u => u.Id == userId);
                if (user == null)
                    throw new ArgumentException("Invalid user.");

                var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
                var orderDtos = orders.Select(order =>
                {
                    var dto = new OrderReadDto();
                    dto.FromEntity(order);
                    return dto;
                });

                return orderDtos;
            }
            catch
            {
                throw new Exception("Error Retrieving Orders!.");
            }
        }

        public async Task<IEnumerable<OrderReadDto>> GetOrdersByStatusAsync(OrderStatus status)
        {
            try
            {
                var orders = await _orderRepository.GetOrdersByStatusAsync(status);
                var orderDtos = orders.Select(order =>
                {
                    var dto = new OrderReadDto();
                    dto.FromEntity(order);
                    return dto;
                });
                return orderDtos;
            }
            catch
            {
                throw new Exception("Error Retrieving Orders!.");
            }
        }

        public async Task<IEnumerable<OrderReadDto>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var orders = await _orderRepository.GetOrdersByDateRangeAsync(startDate, endDate);
                var orderDtos = orders.Select(order =>
                {
                    var dto = new OrderReadDto();
                    dto.FromEntity(order);
                    return dto;
                });
                return orderDtos;

            }
            catch
            {
                throw new Exception("Error Retrieving Orders!.");

            }
        }

        public async Task<decimal> GetTotalPriceByOrderIdAsync(Guid orderId)
        {
            try
            {
                var order = await _orderRepository.GetAsync(o => o.Id == orderId);
                if (order == null)
                    throw new ArgumentException("Order not found.");

                return await _orderRepository.GetTotalPriceByOrderIdAsync(orderId);
            }
            catch
            {
                throw new Exception("Error Retrieving Total price!.");

            }
        }
    }
}