using Core.Domain;
using Core.Repositories;

namespace Core.Tests.Fakes;

public class FakeBasketRepository : IBasketRepository
{
    private Dictionary<int, Basket> _data = new();

    public Task<Basket?> GetAsync(int basketId, CancellationToken cancellationToken)
    {
        _data.TryGetValue(basketId, out var basket);
        return Task.FromResult(basket);
    }

    public void Add(int id, Basket data)
        => _data.Add(id, data);

}
