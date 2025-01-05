using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Initialize the database
        ProductDB productDB = new ProductDB();

        // Initialize checkout system
        Checkout checkout = new Checkout(productDB);

        Console.WriteLine("Welcome to the Supermarket Checkout!");
        Console.WriteLine("Enter item SKUs to scan. Type 'total' to complete your checkout.\n");

        while (true)
        {
            Console.Write("Scan item (or type 'total'): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "total")
            {
                Console.WriteLine("\nFinal Total: " + checkout.CalculateTotal());
                break;
            }

            if (!checkout.ScanItem(input))
            {
                Console.WriteLine("Invalid SKU. Try again.");
            }
        }
    }
}

// Class for Special Offers
class SpecialOffer
{
    public int Quantity { get; set; }
    public int Price { get; set; }

    public SpecialOffer(int quantity, int price)
    {
        Quantity = quantity;
        Price = price;
    }
}

// Mock Database for Products
class ProductDB
{
    public Dictionary<string, (int UnitPrice, SpecialOffer Offer)> Products { get; private set; }

    public ProductDB()
    {
        Products = new Dictionary<string, (int, SpecialOffer)>
        {
            { "A99", (50, new SpecialOffer(3, 130)) },
            { "B15", (30, new SpecialOffer(2, 45)) },
            { "C40", (60, null) },
            { "T34", (99, null) }
        };
    }
}

// Checkout Class
class Checkout
{
    private ProductDB _productDB;
    private Dictionary<string, int> _cart;

    public Checkout(ProductDB productDB)
    {
        _productDB = productDB;
        _cart = new Dictionary<string, int>();
    }

    public bool ScanItem(string sku)
    {
        if (_productDB.Products.ContainsKey(sku))
        {
            if (_cart.ContainsKey(sku))
            {
                _cart[sku]++;
            }
            else
            {
                _cart[sku] = 1;
            }
            Console.WriteLine($"Added {sku} to cart.");
            return true;
        }
        return false;
    }

    public int CalculateTotal()
    {
        int total = 0;

        foreach (var item in _cart)
        {
            string sku = item.Key;
            int quantity = item.Value;
            var product = _productDB.Products[sku];
            int unitPrice = product.UnitPrice;
            SpecialOffer offer = product.Offer;

            if (offer != null)
            {
                int offerGroups = quantity / offer.Quantity;
                int remainingItems = quantity % offer.Quantity;

                total += offerGroups * offer.Price + remainingItems * unitPrice;
            }
            else
            {
                total += quantity * unitPrice;
            }
        }

        return total;
    }
}
