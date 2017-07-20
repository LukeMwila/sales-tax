using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class Item
    {

        public enum ItemCategory { Book, Food, Medical, Other }

        //Private member variables
        private static int itemCount = 0;

        private int id;
        private string name;
        private string description;
        private double shelfPrice;
        private double salesTaxes;
        private bool isImported;
        private int quantity;

        //Properties
        public static double SalesTax { get; set; }
        public static double ImportTax { get; set; }

        public ItemCategory Category { get; set; }
        public long ID { get { return id; } }
        public double SalesTaxes { get { return salesTaxes; } }
        public double Price
        {

            get
            {

                double importTax = 0F;
                double salesTax = 0F;
                double price = 0F;

                //If the item is imported, then import tax applies regardless of the Item category
                if (isImported)
                {
                    importTax += shelfPrice * (ImportTax / 100F);
                }

                //If the item is in the "other" catgeory, then it should be sales tax applies
                if (Category == ItemCategory.Other)
                {
                    salesTax += shelfPrice * (SalesTax / 100F);
                }

                importTax = Math.Round(importTax, 2, MidpointRounding.AwayFromZero);
                salesTax = Math.Round(salesTax, 2, MidpointRounding.AwayFromZero);
                price = shelfPrice + importTax + salesTax;


                return Math.Round(price, 2, MidpointRounding.AwayFromZero);

            }
            set
            {
                shelfPrice = value;
            }

        }// ShelfPrice{}

        public Item
        (
            string name,
            ItemCategory Category,
            string description,
            double shelfPrice,
            bool isImported = false,
            int quantity = 1
        )
        {
            itemCount++;
            this.id = itemCount;
            this.name = name;
            this.Category = Category;
            this.description = description;
            this.shelfPrice = shelfPrice;          
            this.isImported = isImported;
            this.salesTaxes = ComputeTax(shelfPrice, isImported);
            this.quantity = quantity;
        } // end Item()

        private double ComputeTax(double price, bool imported)
        {
            double tax = 0F;

            if (Category == ItemCategory.Other)
            {
                tax += price * (SalesTax / 100F);
            }

            if (imported)
            {
                tax += price * (ImportTax / 100F);
            }

            tax = Math.Round(tax, 2, MidpointRounding.AwayFromZero);

            return tax;
        } // end ComputeTax()

        public void Print()
        {
            String desc = quantity + " " + ((isImported) ? "imported " + description : description);
            Console.WriteLine("{0,-10} {1,-34} {2,16:F2} {3,16:F2}", name, desc, shelfPrice, Price);
        } // end Display()

        public bool Equals(Item other)
        {
            return (other == null) ? false : (ID == other.ID);
        } // end Equals()
    } // end Item{}
}
