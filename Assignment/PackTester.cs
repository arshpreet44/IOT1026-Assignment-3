using System;

namespace Assignment
{
    static class PackTester
    {
        public static void AddEquipment(Pack pack)
        {
            bool addMoreItems = true;
            do
            {
                Console.WriteLine(pack);  // Display the contents of the pack

                // Display the options to add items
                Console.WriteLine("What do you want to add?");
                Console.WriteLine("1 - Arrow");
                Console.WriteLine("2 - Bow");
                Console.WriteLine("3 - Rope");
                Console.WriteLine("4 - Water");
                Console.WriteLine("5 - Food");
                Console.WriteLine("6 - Sword");
                Console.WriteLine("7 - Gather your pack and venture forth");

                try
                {
                    // int.TryParse should be preferred
                    // I am using this method to demonstrate exception handling
                    int choice = Convert.ToInt32(Console.ReadLine());
                    // Can use _ -> for a default case to possibly avoid exception handling
                    InventoryItem newItem = choice switch
                    {
                        1 => new Arrow(),
                        2 => new Bow(),
                        3 => new Rope(),
                        4 => new Water(),
                        5 => new Food(),
                        6 => new Sword(),
                        _ => throw new ArgumentException("Invalid selection")
                    };
                    if (!pack.Add(newItem))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Could not fit this item into the pack.");
                    }
                }
                // Display a message indicating that the user is venturing forth and stop adding more items.  
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is an invalid selection.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Venturing Forth!");
                    addMoreItems = false;
                }
                Console.ResetColor(); // Reset the console color to the default.
            } while (addMoreItems); // Repeat the loop while `addMoreItems` is true, allowing the user to add more items.
        }
    }
}
