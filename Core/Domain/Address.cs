namespace Core.Domain;

public class Address
{
    public Address(string v1, string v2, string v3, string v4, string v5)
    {
        V1 = v1;
        V2 = v2;
        V3 = v3;
        V4 = v4;
        V5 = v5;
    }

    public string V1 { get; }
    public string V2 { get; }
    public string V3 { get; }
    public string V4 { get; }
    public string V5 { get; }


}


