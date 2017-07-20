using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class ShoppingCart
    {

        //Member variables
        private List<Item> items;
        private string name;

        //Properties
        public List<Item> Items { get { return items; } }

        public ShoppingCart(string name)
        {
            this.name = name;
            items = new List<Item>();
        }// end ShoppingCart()

        public void Add(Item item)
        {
            items.Add(item);
        }

        public void Remove(Item item)
        {
            items.Remove(item);
        }

        public void PrintReceipt()
        {
            Console.WriteLine(name.ToUpper());

            if (items.Count > 0)
            {
                double total = 0F;
                double salesTax = 0F;
                Console.WriteLine("{0,-10} {1,-34} {2,16} {3,16}", "Name", "Description", "($) Price", "($) Price [+Tax]");
                foreach (Item item in items)
                {
                    item.Print();
                    total += item.Price;
                    salesTax += item.SalesTaxes;
                }
                HorizontalRule(80);
                Console.WriteLine("{0,-10} {1,68}", "SALES TAX", salesTax);
                HorizontalRule(80);
                Console.WriteLine("{0,-10} {1,68}", "TOTAL", total);
                HorizontalRule(80);
            }
            else
            {
                Console.WriteLine("Shopping Cart Empty");
            }

            Console.WriteLine("\n");
        } // end Display()

        private static void HorizontalRule(int ruleWidth)
        {
            for (int i = 0; i < ruleWidth; i++)
            {
                if (i < (ruleWidth - 1))
                {
                    Console.Write("-");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        } // end HorizontalRule()
    } // end ShoppingCart{}
}
