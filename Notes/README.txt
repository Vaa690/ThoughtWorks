Explanation of Design:

My design is comprised of two classes (not including unit testing):

- Class SalesTaxes: The SalesTaxes class contains the Main() function. The program reads the text file, line-by-line, and pasrses each word into a string array.
		Each line of the input text is passing the same peices information about each item in the same order. When the line is parsed, if the first index is not "Input" or null,
		the tokens are passed to the item class where information on the item is gathered, and sales tax per item (as well as receipt display per item) is calculated. There are
		two counters in this class, totalSalesTax and receiptTotal. Every time a line of input is looped through, the price of the item with sales tax, and just the sales tax on
		the item is returned and added to the counter for the output. At the same time, a string is being passed from the items class that is stored in a list of strings and 
		displayed on the output. If the first index of the array is " ", then the program knows that the current input is over. It will store each item with the price (plus tax), 
		the total sales tax, and the receipt total. The program will then set all of the totals back to zero, in order to prepare for the next set of inputs. The next expected 
		token is "Input". This is the marker for a new set of input. This function will repeat until the Reader tries to read a null line. At this point, the program will escape 
		the loop, and print out each string in the receipt string list. 
		
- Class Item: The Item class holds all of the information about the item that could be gathered from the input. I proceeded under the assumption that the input 
		format will be consistent. This way, the first character is the quantity, and the last entry is the price. The name relies on strict, consistent, 
		formatting. Any parsed tokens that were between the first index and second last index are part of the name. (index[1] to index[tokens.Length - 2]).
		After parsing the input line, quantity, name, and price of the items are stored as fields of the item class. The quantity of the item is checked first. If there is more 
		than one of a specific item, it will be added up to one price and taxed all at once. The item name field is used to dictate the tax on an item (taxable or imported). 
		There are two class Boolean variable, isTaxable and isImported, that will change based on item name. based on keywords, the program will tell whether or not an item is
		subject to standard tax, import tax, or tax exempt. The member constants, standard and imported tax, are declared in the item class to compute sales tax on each item. When
		the price of the item after tax has been calculated, a member method takes the item quantity, name, and price after tax to create a string that will be used on the receipt.
		Each line of text that is read, goes through this process, returning a string formatted for the receipt. The SalesTaxes class then pulls this string, and saves it in a list.
		After all of the lines have been fed as objects to the Item class, the receipt list displays each line, creating the receipt. 
		


Assumptions Throughout Code:

- Every input item will be in the following format: "quantity" "item name" "at" "price" (ex. 1 book at 12.95)
- Assume that every list of items is separated by "Input n:"
- All food items will have the string "chocolate" in the item name
- All books will have the string "book" in the item name
- All medical supplies will have the string "pill" in the item name
- All imported goods will have the string "import" in the item name
- Assume that no calculations requiring more than +/- 0.01 precision is necessary (use decimal type)
