using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geburtstags_Informant
{
    internal class AddItemMenu : Menu
    {
        public override void ShowDisplayMenu()
        {
            Console.WriteLine("Bitte gebe die geforderten Informationen an");
            Menu.ShowCancelOption();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine();
            switch (ItemListMenuHelper.SelectedListValue)
            {
                case 0:
                    UserInputPlantName();
                    break;
                case 1:
                    string giftName = UserInputGiftName();
                    int giftYear = UserInputGiftYear();
                    ItemListMenuHelper.AddItem(giftName, giftYear);
                    break;
            }
        }
        private void UserInputPlantName()
        {
            string input;
            Menu nextMenu;

            while (true)
            {
                Console.Write("Name der");
                Menu.WriteInColor(" Pflanze", ItemListMenuHelper.ItemColor);
                Console.Write(": ");
                input = Console.ReadLine().ToString();
                if (input != "cancel")
                {
                    ItemListMenuHelper.AddItem(input);
                }
                else
                {
                    nextMenu = new ItemListMainMenu();
                }
            }
        }

        public static string UserInputGiftName()
        {
            string input;
            Menu nextMenu;

            while (true)
            {
                Console.Write("Name des");
                Menu.WriteInColor(" Geschenkes", ItemListMenuHelper.ItemColor);
                Console.Write(": ");
                input = Console.ReadLine().ToString();
                if (input != "cancel")
                {
                    return input;
                }
                else
                {
                    nextMenu = new ItemListMainMenu();
                }
            }
        }
        public static int UserInputGiftYear()
        {
            string input;
            Menu nextMenu;

            while (true)
            {
                Menu.WriteInColor("Verschenkt", ItemListMenuHelper.ItemColor);
                Console.Write(" im Jahr: ");
                input = Console.ReadLine().ToString();
                if (input != "cancel")
                {
                    try
                    {
                        return Convert.ToInt32(input);
                    }
                    catch (System.FormatException)
                    {
                        Menu.WriteLineInColor("Fehler! Bitte gebe das Jahr in Zahlen an.", ConsoleColor.Red);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Menu.WriteLineInColor($"{ex}", ConsoleColor.Red);
                        Console.WriteLine();
                    }
                }
                else
                {
                    nextMenu = new ItemListMainMenu();
                }
            }
        }
    }
}
