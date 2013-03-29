using System;
using System.IO;
using System.Collections.Generic;

namespace ThoughtWorks
{
    /* TODO:
     * 
     * Note in correct sample outputs
     * type up the reason for design
     * comment code
     * give instructions on use
     * Provide a unit testing page
     * */

    public class SalesTaxes
    {
        public static void Main()
        {
            string line;
            List<string> receipt = new List<string>();

            Console.WriteLine("Enter the path of the input file you wish to use, or enter 'default' to use the sample input provided:\n\n");
            Console.WriteLine("NOTE: Do NOT use quatation marks\n");

            string cmdinpt = Console.ReadLine();
            Console.WriteLine("-------------------------\n\n");

            if(cmdinpt == "default")
            {
                cmdinpt = "Inputs\\input.txt";
            }

            try
            {
                using (StreamReader sr = new StreamReader(cmdinpt))
                {
                    decimal totalSalesTax = 0;
                    decimal receiptTotal = 0;
                    // while the next line of the input is not null, add each input line to the list
                    // Assume if there are n inputs they will be seperated by "Input n:".
                    // Assume that in between inputs there is a " " so it is not read as Null.
                    while ((line = sr.ReadLine()) != null)
                    {

                        string[] tokens = line.Split(new char[] { ' ' });
              
                        if (tokens[0] != "Input" && tokens[0] != "")
                        {
                            var item = new Item(tokens);
                            var priceForReceipt = item.ReceiptRepresentation();
                            receipt.Add(priceForReceipt);

                            decimal salesTax = item.CalcSalesTaxPerItem();
                            totalSalesTax = totalSalesTax + salesTax;

                            decimal total = item.CalcPriceAfterTax();
                            receiptTotal = receiptTotal + total;
                        }

                        if (tokens[0] == "Input")
                        {
                            // Display output number based on input number
                            string inputNumber = tokens[1].Substring(0, 1);
                            int outputNumber = Convert.ToInt32(inputNumber);
                            receipt.Add("Output " + outputNumber + ": \n");
                        }

                        if (tokens[0] == "")
                        {
                            receipt.Add("Sales Taxes: " + decimal.Round(totalSalesTax, 2));
                            receipt.Add("\nTotal: " + decimal.Round(receiptTotal, 2) + "\n\n");
                            // Erase the counter each input to use in calculating total sales tax
                            totalSalesTax = 0;
                            receiptTotal = 0;
                        }
                    }

                    // Assumption: Last Input is followed by "Null"
                    // Add Sales Tax to final input receipt before printing
                    receipt.Add("Sales Taxes: " + decimal.Round(totalSalesTax, 2));
                    receipt.Add("\nTotal: " + decimal.Round(receiptTotal, 2));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            foreach (var p in receipt)
            {
                Console.Write(p);
            }

            Console.WriteLine("\n\nPress Enter to close the program:\n");
            Console.ReadLine();
        }
    }
}
