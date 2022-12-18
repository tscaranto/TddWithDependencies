using Core.Domain;

namespace Core.Repositories
{
    public interface IOrderRepository
    {
        public Task AddAsync(Order order, CancellationToken cancellationToken);
    }
}