﻿using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesShoppingUI
{
    internal class Program
    {
        static ShoppingCartModel cart = new ShoppingCartModel();
        static void Main(string[] args)
        {
            PopulateCartWithDemoData();

            // Standard numeric format strings: formats a numeric value as a currency string, 2 # after the decimal point.
            // NO white space after C2 - part of format.
            // SubToalAlert NO(), only matters the signature eg. pass in decimal type, return void.
            // ;
            Console.WriteLine($"The total for the cart is {cart.GenerateTotal(SubToalAlert, CalculateLeveledDiscount, AlerUser):C2}");
            Console.WriteLine();

            // above line code, in a line.
            decimal total = cart.GenerateTotal((subTotal) => Console.WriteLine($"The subtotal for cart 2 is {subTotal:C2}"),
                (products, subTotal) => { // more than one line, use {}.
                    if (products.Count > 3)
                    {
                        return subTotal * 0.5M;
                    }
                    else
                    {
                        return subTotal;
                    }
                },
                (message) => Console.WriteLine($"Cart 2 Alert: {message}"));

            Console.WriteLine($"The total for cart 2 if {total:C2}");
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Please press any key to exit the application...");
            Console.ReadKey();
        }

        private static void SubToalAlert(decimal subTotal)  // The method is used to pass in
        {
            Console.WriteLine($"The subtotal is {subTotal:C2}");  // NB: no thread safe
        }

        private static void AlerUser(string message)
        {
            Console.WriteLine(message);
        }

        private static decimal CalculateLeveledDiscount(List<ProductModel> items, decimal subTotal) // Func
        {
            if (subTotal > 100)
            {
                return subTotal * 0.80M;
            }
            else if (subTotal > 50)
            {
                return subTotal * 0.85M;
            }
            else if (subTotal > 10)
            {
                return subTotal * 0.95M;
            }
            else
            {
                return subTotal;
            }
        }

        private static void PopulateCartWithDemoData()
        {
            cart.Items.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M });
            cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
            cart.Items.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
            //cart.Items.Add(new ProductModel { ItemName = "Blueberries", Price = 8.84M });
        }
    }
}
