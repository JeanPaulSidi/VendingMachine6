using System.Text.Json;

namespace VendingMachine6
{
    internal class Program
    {
        static void DisplayMenu(string JsonStock)
        {
            var Stock = JsonSerializer.Deserialize<List<Item>>(JsonStock);
            int i = 0;

            Console.WriteLine("****************** VENDING MACHINE ******************");
            Console.WriteLine();

            foreach (var item in Stock)
            {
                i++;
                Console.WriteLine($"{i} - {item.Name}  {item.Price.ToString("C")}   Count:{item.Count}");
            }

            Console.WriteLine("*****************************************************");
        }

        static int GetUserChoice()
        {
            string Userinput;
            int UserChoice;

            Console.WriteLine();
            Console.Write("Enter your choice: ");
            Userinput = Console.ReadLine();

            while (!int.TryParse(Userinput, out UserChoice))
            {
                Console.Write("Please enter a whole number: ");
                Userinput = Console.ReadLine();
            }

            return UserChoice;
        }

        static void ReturnToMenu()
        {
            Console.WriteLine();
            Console.Write("Press any key to return to make another selection.");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            int UserChoice;
            string PurchasedItem = string.Empty;
            string JsonStock = string.Empty;
            int InventoryCount;
            VendingMachine VendingManager = new VendingMachine();

            InventoryCount = VendingManager.GetInventoryCount();

            do
            {
                JsonStock = VendingManager.GetStock();
                DisplayMenu(JsonStock);
                UserChoice = GetUserChoice();

                while (UserChoice <= 0 || UserChoice > InventoryCount)
                {
                    Console.WriteLine("Input must be between 1 and " + InventoryCount);
                    UserChoice = GetUserChoice();
                }

                PurchasedItem = VendingManager.BuyItem(UserChoice);
                Console.WriteLine();
                if (PurchasedItem == string.Empty)
                {
                    Console.WriteLine("The item you try to purchase is out of stock");
                }
                else
                {
                    Console.WriteLine("Thank you. Vending of " + PurchasedItem);
                }

                ReturnToMenu();

            } while (true);
        }

    }
}
}
