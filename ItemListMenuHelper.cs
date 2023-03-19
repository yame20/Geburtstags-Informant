using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geburtstags_Informant
{
    internal static class ItemListMenuHelper
    {   
        public static byte SelectedListValue { get; set; }
        public static string Titel { get; set; }
        public static string OptionName { get; set; }
        public static ConsoleColor ItemColor { get; set; }
        public static List<IItem> SelectedList { get; set; }

        public enum ItemLists
        {
            PlantList,
            GiftList
        }

        public static void InitializePropertys(ItemLists selectedList)
        {
            switch (selectedList)
            {
                case ItemLists.PlantList:
                    Titel = "Lieblingspflanzen";
                    OptionName = "Pflanze";
                    SelectedListValue = 0;
                    ItemColor = ConsoleColor.Green;
                    SelectedList = ProfileManager.CurrentProfile.FavouritPlants;
                    break;
                case ItemLists.GiftList:
                    Titel = "Überreichte Geschenke";
                    OptionName = "Geschenk";
                    SelectedListValue = 1;
                    ItemColor = ConsoleColor.DarkYellow;
                    SelectedList = ProfileManager.CurrentProfile.GiftedList;
                    break;
            }
        }

        public static void ShowItemsInList()
        {    
            if (SelectedList.Count<IItem>() == 0)
            {
              Console.WriteLine("Leider ist noch nichts eingetragen worden.");
            }
            else
            {
                ProfileManager.CurrentProfile.ShowItemsOnDisplay();
            }
        }

        public static void AddItem(string input)
        {
            Plant plant = new Plant(input);
            ProfileManager.CurrentProfile.ItemToList(plant);
            Menu.WriteLineInColor($"{plant.Name} wurde hinzugefügt! :)", ConsoleColor.Green);
            Console.WriteLine();
            Console.Write("Drücken sie eine beliebige Taste... ");
            Console.ReadKey();
            Menu nextMenu = new ItemListMainMenu();
        }
        public static void AddItem(string giftName, int giftYear)
        {
            Gift gift = new Gift(giftName, giftYear);
            ProfileManager.CurrentProfile.ItemToList(gift);
            Menu.WriteLineInColor($"{gift.Name} wurde hinzugefügt! :)", ConsoleColor.Green);
            Console.WriteLine();
            Console.Write("Drücken sie eine beliebige Taste... ");
            Console.ReadKey();
            Menu nextMenu = new ItemListMainMenu();
        }
        
        public static void RemoveItem(string input)
        {
            Menu nextMenu;
            int itemsInList = 0;
             
            if (SelectedList != null)
            {
                foreach (IItem item in SelectedList)
                {
                   if (item.Name == input)
                   {
                        ProfileManager.CurrentProfile.RemoveItemFromList(item, SelectedList);
                        itemsInList++;
                        Menu.WriteLineInColor($"[{item.Name}] wurde aus der Liste entfernt.", ConsoleColor.Green);
                        Console.WriteLine();
                        Console.Write("Drücken sie eine beliebige Taste... ");
                        Console.ReadKey();
                        nextMenu = new ItemListMainMenu();
                   }
                }
                if (itemsInList == 0 && SelectedList.Count<IItem>() != 0)
                {
                   Menu.WriteLineInColor($"Fehler! [{input}] steht nicht in der Liste.", ConsoleColor.Red);
                   Console.WriteLine();
                }
            }
            if (SelectedList.Count<IItem>() == 0)
            {
                Menu.WriteLineInColor($"Fehler! Es stehen keine Items in der Liste", ConsoleColor.Red);
                Console.WriteLine();
            } 
        }
    }
}

