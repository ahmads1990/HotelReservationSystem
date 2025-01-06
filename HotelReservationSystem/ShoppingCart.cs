namespace HotelReservationSystem;
using System;
using System.Collections.Generic;
using System.Linq;

// public class ShoppingCart
// {
//     public List<CartItem> Items { get; set; } = new();
//
//     public decimal CalculateTotalPrice()
//     {
//         if (Items == null || !Items.Any())
//         {
//             Console.WriteLine("The cart is empty");
//             return 0;
//         }
//
//         decimal total = Items.Sum(item => CalculateItemTotal(item));
//
//         Console.WriteLine($"Total price of cart: {total}");
//         return total;
//     }
//
//     private decimal CalculateItemTotal(CartItem item)
//     {
//         if (item.Quantity <= 0)
//         {
//             Console.WriteLine($"Item {item.Name} has an invalid quantity: {item.Quantity}");
//             return 0;
//         }
//
//         decimal itemTotal = item.Quantity * item.Price;
//
//         if (item.IsDiscounted && item.DiscountPercentage > 0)
//         {
//             itemTotal -= itemTotal * (item.DiscountPercentage / 100);
//         }
//
//         return itemTotal;
//     }
// }
//
// public class CartItem
// {
//     public string Name { get; set; } = string.Empty;
//     public decimal Price { get; set; }
//     public int Quantity { get; set; }
//     public bool IsDiscounted { get; set; }
//     public decimal DiscountPercentage { get; set; }
//     
// }
//



//public class ShoppingCart
//{
//    public List<CartItem> Items { get; set; }
//    public decimal CalculateTotalPrice()
//    {
//        decimal total = 0;
//        foreach (var item in Items)
//        {
//            if (item.Quantity > 0)
//            {
//                decimal itemTotal = item.Quantity * item.Price;
//                if (item.IsDiscounted)
//                {
//                    itemTotal -= itemTotal * item.DiscountPercentage / 100;
//                }
//                total += itemTotal;
//            }
//            else
//            {
//                Console.WriteLine($"Item {item.Name} has an invalid quantity: {item.Quantity}");
//            }
//        }
//        Console.WriteLine($"Total price of cart: {total}");
//        return total;
//    }
//}

// Solution

public class ShoppingCart
{
    public List<CartItem> Items { get; set; }

    public decimal CalculateTotalPrice()
    {
        var validItems = ValidateItems();
        var total = validItems.Sum(item => CalculateItemTotal(item));

        Log($"Total price of cart: {total}");
        return total;
    }

    private IEnumerable<CartItem> ValidateItems()
    {
        foreach (var item in Items)
        {
            if (item.Quantity <= 0)
            {
                Log($"Item {item.Name} has an invalid quantity: {item.Quantity}");
            }
            else
            {
                yield return item;
            }
        }
    }

    private decimal CalculateItemTotal(CartItem item)
    {
        var itemTotal = item.Quantity * item.Price;
        if (item.IsDiscounted)
        {
            itemTotal -= itemTotal * item.DiscountPercentage / 100;
        }
        return itemTotal;
    }

    private void Log(string message)
    {
        // Placeholder for a more robust logging mechanism in the future
        Console.WriteLine(message);
    }
}

public class CartItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public bool IsDiscounted { get; set; }
    public decimal DiscountPercentage { get; set; }
}