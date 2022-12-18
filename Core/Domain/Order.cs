namespace Core.Domain;

public class Order
{
    public Order(int basketId, string buyerID, Address shipping)
    {
        BasketId = basketId;
        buyerId = buyerID;
        shippingAddress = shipping;
    }

    public int BasketId { get; }
    public string buyerId { get; }
    public Address shippingAddress { get; }
    public string V3 { get; }
    public string V4 { get; }
    public string V5 { get; }
}
