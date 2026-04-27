using ShopAPI.Domain.Common;

namespace ShopAPI.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    public static Product Create(string name, string description, decimal price, int stock)
    {
        return new Product
        {
            Name = name,
            Description = description,
            Price = price,
            Stock = stock
        };
    }

    public void Updateprice(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new ArgumentException("Podaj cenę większą od zera");

        Price = newPrice;


    }
    public void AddStock(int quantity)
    {
       if (quantity <= 0)
        throw new ArgumentException("Ilość musi być większa od zera.");


        Stock += quantity;

    }

}

