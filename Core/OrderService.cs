using Core.Domain;
using Core.Exceptions;
using Core.Repositories;

namespace Core
{
    public class OrderService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IBasketRepository basketRepository, IOrderRepository orderRepository)
        {
            _basketRepository = basketRepository;
            _orderRepository = orderRepository; 
        }

        public async Task CreateOrderAsync(int basketId, Address? shippingAddress, CancellationToken cancellationToken)
        {
            if (shippingAddress is null)
                throw new ArgumentNullException();

            var basket = await _basketRepository.GetAsync(basketId, cancellationToken);

            if (basket is null)
                throw new BasketNotFoundException();

            var order = new Order(basketId, basket.BuyerId, shippingAddress);
            await _orderRepository.AddAsync(order, cancellationToken);
        }



    }
}