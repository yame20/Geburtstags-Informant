using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geburtstags_Informant
{
    internal class RemoveItemMenu : Menu
    {
        public override void ShowDisplayMenu()
        {
            Console.Write("Welche/s ");
            Menu.WriteInColor(ItemListMenuHelper.OptionName, ItemListMenuHelper.ItemColor);
            Console.WriteLine(" möchtest du entfernen?");
            Menu.ShowCancelOption();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine();
            ItemListMenuHelper.ShowItemsInList();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine();
            UserInput();
        }
        private void UserInput()
        {
            string input;
            Menu nextMenu;

            while (true)
            {
                Console.Write("Eingabe: ");
                input = Console.ReadLine().ToString();
                if (input != "cancel")
                {
                    ItemListMenuHelper.RemoveItem(input);
                }
                else
                {
                    nextMenu = new ItemListMainMenu();
                }
            }
        }
    }
}
