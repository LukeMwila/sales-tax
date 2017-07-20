using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class SalesTax
    {

        public static void Main(String[] args)
        {

            // Set Sales and Import Tax
            Item.SalesTax = 10F;    // 10 %
            Item.ImportTax = 5F;    // 5 %

            // Input 1
            ShoppingCart input1 = new ShoppingCart("Input 1");
            input1.Add(new Item("Beyond", Item.ItemCategory.Book, "book", 12.49F));
            input1.Add(new Item("Gravity", Item.ItemCategory.Other, "music CD", 14.99F));
            input1.Add(new Item("Cadbury", Item.ItemCategory.Food, "chocolate bar", 0.85F));

            // Input 2
            ShoppingCart input2 = new ShoppingCart("Input 2");
            input2.Add(new Item("Lindt", Item.ItemCategory.Food, "box of chocolates", 10.0F, true));
            input2.Add(new Item("Star", Item.ItemCategory.Other, "bottle of perfume", 47.50F, true));

            // Input 3
            ShoppingCart input3 = new ShoppingCart("Input 3");
            input3.Add(new Item("Hugo Boss", Item.ItemCategory.Other, "bottle of perfume", 27.99F, true));
            input3.Add(new Item("Dunhill", Item.ItemCategory.Other, "bottle of perfume", 18.99F));
            input3.Add(new Item("Disprin", Item.ItemCategory.Medical, "packet of headache pills", 9.75F));
            input3.Add(new Item("Crunchie", Item.ItemCategory.Food, "box of chocolates", 11.25F, true));

            // Output 1
            input1.PrintReceipt();

            // Output 2
            input2.PrintReceipt();

            // Output 3
            input3.PrintReceipt();

            Console.ReadLine();
        } // end Main()

    } // Main{}
}
