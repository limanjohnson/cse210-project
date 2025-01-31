using System;
using OnlineOrdering;

class Program
{
    static void Main(string[] args)
    {
        // Addresses
        Address address1 = new Address("123 Main St", "Riverton", "UT", "USA");
        Address address2 = new Address("456 Maple Rd", "Saratoga Springs", "UT", "USA");
        Address address3 = new Address("789 Elm St", "Leeds", "West Yorkshire", "England");
        
        // Customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Doe", address2);
        Customer customer3 = new Customer("Tom Don", address3);
        
        // Products
        Product iPhone = new Product("iPhone 16", 800.29, 2, 1);
        Product macBook = new Product("MacBook Pro", 2400, 1, 2);
        Product iPad = new Product("iPad Pro", 1200, 1, 3);
        
        // Order
        Order order1 = new Order(customer1);
        order1.AddProduct(iPhone);
        order1.AddProduct(iPad);
        
        Order order2 = new Order(customer2);
        order2.AddProduct(macBook);
        order2.AddProduct(iPad);

        Order order3 = new Order(customer3);
        order3.AddProduct(iPhone);
        
        // Display order Details

        Console.WriteLine("Order 1:");
        Console.WriteLine("\nPacking Label\n" + order1.PackingLabel());
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine("\nShipping Label\n" + order1.ShippingLabel());
        Console.WriteLine("\nTotal Cost: $" + order1.GetTotalPrice());
        Console.WriteLine();
        Console.WriteLine("Order 2:");
        Console.WriteLine("\nPacking Label\n" + order2.PackingLabel());
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine("\nShipping Label\n" + order2.ShippingLabel());
        Console.WriteLine("\nTotal Cost: $" + order2.GetTotalPrice());
        Console.WriteLine();
        Console.WriteLine("Order 3:");
        Console.WriteLine("\nPacking Label\n" + order3.PackingLabel());
        Console.WriteLine(order3.ShippingLabel());
        Console.WriteLine("\nShipping Label\n" + order3.ShippingLabel());
        Console.WriteLine("\nTotal Cost: $" + order3.GetTotalPrice());

    }
}