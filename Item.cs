using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThoughtWorks
{
    class Item
    {
        static decimal standard = 0.10M;
        static decimal imported = 0.05M;

        int quantity;
        string name;
        decimal priceBeforeTax;
        decimal newPriceBeforeTax;
        bool isTaxable;
        bool isImported;
        decimal priceAfterTax;

        public Item(string[] tokens)
        {
            // Find the quantity, name, and price of each item from input line
            // Assume that the order is always the same in the input (ex. "quantity" "name" at "price")
            quantity = int.Parse(tokens[0]);
            name = tokens[1];
            for (int i = 2; i < tokens.Length - 2; i++)
            {
                name = name + " " + tokens[i];
            }
            priceBeforeTax = decimal.Parse(tokens[tokens.Length - 1]);

            PriceBasedOnQuantity();
            CheckIfItemIsImported();
            CheckIfItemIsTaxable();
            CalcPriceAfterTax();
            ReceiptRepresentation();
            CalcSalesTaxPerItem();
        }

        // If quantity is more than one, find the price for all
        // Otherwise, just return the given priceBeforeTax
        // Use the new price for calculating total sales tax
        public decimal PriceBasedOnQuantity()
        {
            if (quantity > 1)
            {
                newPriceBeforeTax = priceBeforeTax * quantity;
                return newPriceBeforeTax;
            }

            newPriceBeforeTax = priceBeforeTax;
            return newPriceBeforeTax;
        }

        // See if Item is imported 
        // Assume that if an item is imported it will have "imported" in the name
        public bool CheckIfItemIsImported()
        {
            string searchString = "imported";
            isImported = name.Contains(searchString);

            return isImported;
        }

        // I am going to assume the following: 
        // if it is a book, it will have "book" in the name
        // if it is food, it will have "chocolate" in the name
        // if it is medical supplies, it will have "pill" in the name
        public bool CheckIfItemIsTaxable()
        {
            bool isBook = name.Contains("book");
            bool isFood = name.Contains("chocolate");
            bool isMedical = name.Contains("pill");

            bool isNotTaxable = (isBook | isMedical | isFood);
            isTaxable = !isNotTaxable;
            return isTaxable;
        }

        // If imported and taxable - sales tax = 15%
        // If imported and not taxable - sales tax = 05%
        // If taxable and not imported - sales tax = 10%
        public decimal CalcPriceAfterTax()
        {
            if (isImported && isTaxable)
            {
                priceAfterTax = priceBeforeTax + (priceBeforeTax * (standard + imported));
                return priceAfterTax;
            }
            
            if (isImported && !isTaxable)
            {
                priceAfterTax = priceBeforeTax + (priceBeforeTax * imported);
                return priceAfterTax;
            }

            if (!isImported && isTaxable)
            {
                priceAfterTax = priceBeforeTax + (priceBeforeTax * standard);
                return priceAfterTax;
            }

            priceAfterTax = priceBeforeTax;
            return priceAfterTax;
        }

        public string ReceiptRepresentation()
        {
            // Format information for output
            // example output: 1 book : 12.49
            string roundedPrice = String.Format("{0:0.00}", priceAfterTax);
            string writeToReceipt = quantity + " " + name + ": " + roundedPrice + "\n";

            return writeToReceipt;
        }

        // return the salestax per Item. Use this to calculate total sales tax of a full input.
        public decimal CalcSalesTaxPerItem()
        {
            decimal salesTax = priceAfterTax - newPriceBeforeTax;
            return salesTax;
        }
    }
}
