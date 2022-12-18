using Core.Domain;
using Core.Exceptions;
using Core.Repositories;
using Core.Tests.Fakes;
using FluentAssertions;

namespace Core.Tests;
public class CreateOrderTests
{
    [Fact]
    public async Task GivenAnInvalidBasketId_ThenThrowBasketNotFoundException()
    {
        IBasketRepository basketRepository = new FakeBasketRepository();
        var service = new OrderService(basketRepository, new FakeOrderRepository());

        var action = () => service.CreateOrderAsync(10, ShippingAddress(), default(CancellationToken));

        await action.Should()//NonGenericAsyncFunctionAssertions
            .ThrowAsync<BasketNotFoundException>();
    }

    [Fact]
    public async Task GivenNullShippingAddress_ThenThrowShippingAddressNotFoundException()
    {
        IBasketRepository basketRepository = new FakeBasketRepository();
        var service = new OrderService(basketRepository, new FakeOrderRepository());

        var action = () => service.CreateOrderAsync(10, null, default(CancellationToken));

        await action.Should()//NonGenericAsyncFunctionAssertions
            .ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task GivenValidBasket_ThenAddOrderToRepository()
    {
        var basketRepository = new FakeBasketRepository();
        basketRepository.Add(10, new Basket("GF"));
        var orderRepository = new FakeOrderRepository();
        var service = new OrderService(basketRepository, orderRepository);

        await service.CreateOrderAsync(10, ShippingAddress(), default(CancellationToken));

        orderRepository.Get(10)
            .Should()
            .NotBeNull();
    }

    private static Address ShippingAddress()
       => new Address("BlaBla", "bla", "bla", "bla", "1000");


}
