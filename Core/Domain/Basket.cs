using Core.Repositories;

namespace Core.Domain;

public class Basket
{
    public Basket(string _BuyerId )
    {
        BuyerId = _BuyerId;


    }

    public int BasketId { get; }
    public string BuyerId { get; }
    
}
