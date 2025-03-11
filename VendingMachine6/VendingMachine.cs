using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VendingMachine6
{
    public class VendingMachine
    {
        private List<Item> _inventory = new List<Item>();
        private string _jsonString = string.Empty;
        public VendingMachine()
        {
            InitializeInventory();
            UpdateStock();
        }
        public int GetInventoryCount()
        {
            return _inventory.Count;
        }
        private void InitializeInventory()
        {
            _inventory.Clear();
            _inventory.Add(new Item("Pepsi", 1.5m, 10));
            _inventory.Add(new Item("Coke", 1.5m, 10));
            _inventory.Add(new Item("Snack", 2m, 8));
            _inventory.Add(new Item("Doritos", 1.75m, 6));
            _inventory.Add(new Item("Energy Drink", 2.5m, 20));
            _inventory.Add(new Item("Mixed Fruit Gummies", 1.25m, 15));
            _inventory.Add(new Item("Poptarts", 2.25m, 3));
        }
        private void UpdateStock()
        {
            _jsonString = JsonSerializer.Serialize(_inventory);
            File.WriteAllText("Stock.json", _jsonString);
        }
        public string GetStock()
        {
            return _jsonString;
        }
        public string BuyItem(int Index)
        {
            Item PickedItem = _inventory[Index - 1];
            if (PickedItem.Count > 0)
            {
                PickedItem.Count--;
                UpdateStock();
                return PickedItem.Name;
            }
            else
            {
                return string.Empty;
            }
        }

    }
}
