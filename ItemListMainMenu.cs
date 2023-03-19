using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geburtstags_Informant
{
    internal class ItemListMainMenu : Menu
    {
        public override void ShowDisplayMenu()
        {
            Menu.WriteLineInColor(ItemListMenuHelper.Titel, ItemListMenuHelper.ItemColor);
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine();
            ItemListMenuHelper.ShowItemsInList();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Wähle eine Aktion: ");
            Console.WriteLine();

            Console.Write("[1] ");
            Menu.WriteInColor(ItemListMenuHelper.OptionName, ItemListMenuHelper.ItemColor);
            Console.WriteLine(" hinzufügen");

            Console.Write("[2] ");
            Menu.WriteInColor(ItemListMenuHelper.OptionName, ItemListMenuHelper.ItemColor);
            Console.WriteLine(" entfernen");

            Console.Write("[3] ");
            Menu.WriteLineInColor("Zurück", ConsoleColor.Red);
            Console.WriteLine();

            Console.WriteLine("--------------------------------------------------------");
            InputOption();
        }
        
        private void InputOption()
        {
            string input = "";
            Menu nextMenu;

            while (true)
            {
                Console.Write("Eingabe: ");
                input = Console.ReadLine().ToString();
                
                switch (input)
                {
                    case "1":
                        nextMenu = new AddItemMenu(); 
                        break;
                    case "2":
                        nextMenu = new RemoveItemMenu();
                        break;
                    case "3":
                        nextMenu = new ProfileMainMenu();
                        break;

                    default:                      
                        Menu.WriteLineInColor("Fehler! Bitte mache eine gültige Eingabe.", ConsoleColor.Red);
                        Console.WriteLine();
                        break;
                } 
            }
        }
    }
}
