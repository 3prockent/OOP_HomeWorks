using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Item
    {
    }
    class Order : Item
    {
        private List<Item> itemList { get; set; }
        private List<Item> ItemList
        {
            get
            {
                return itemList;
            }
            set
            {
                itemList = value;
            }
        }
        private class Book : Order
        {
            public void CalculateTotalSum() {/*...*/}
            public void GetItems() {/*...*/}
            public void GetItemCount() {/*...*/}
        }
        private class ItemRepository : Order{
            public void Load(Item item) {/*...*/}
            public void Save(Item item) {/*...*/}
            public void Update() {/*...*/}
            public void Delete() {/*...*/}

        }
       private class ChangedItem : Order{
        public void AddItem(Item item) {/*...*/}
        public void DeleteItem(Item item) {/*...*/}
        public void PrintOrder() {/*...*/}
        public void ShowOrder() {/*...*/}
    }
    }
    class Program
    {
        static void Main(string[] arg)
        {
            Item a = new Item();
            Console.WriteLine(a.ToString());
        }
    }
    }

