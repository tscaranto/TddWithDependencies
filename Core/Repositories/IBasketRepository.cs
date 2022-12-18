using Core.Domain;

namespace Core.Repositories;

public interface IBasketRepository
{
    public Task<Basket> GetAsync(int basketId, CancellationToken cancellationToken);
}


