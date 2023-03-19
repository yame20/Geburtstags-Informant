using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geburtstags_Informant
{
    internal class ProfileMainMenu : Menu
    {
        public override void ShowDisplayMenu()
        {
            Console.Write("Wilkommen im");
            Menu.WriteInColor(" Profil", ConsoleColor.Cyan);
            Console.WriteLine(" von: ");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine();
            
            Menu.WriteLineInColor($"{ProfileManager.CurrentProfile.FirstName} {ProfileManager.CurrentProfile.LastName}", ConsoleColor.Cyan);
            
            Console.Write("Geboren am:");
            Menu.WriteInColor($" {ProfileManager.CurrentProfile.BirthdayDate.ToShortDateString()}", ConsoleColor.Magenta);
            Console.Write(" || Alter:");
            Menu.WriteLineInColor($" {ProfileManager.ShowAgeInYears()} ", ConsoleColor.Magenta);

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Wähle eine Aktion: ");
            Console.WriteLine();
            Console.Write("[1]");
            Menu.WriteInColor(" Lieblingspflanzen", ConsoleColor.Green);
            Console.WriteLine(" anzeigen");

            Console.Write("[2] Überreichte");
            Menu.WriteLineInColor(" Geschenke", ConsoleColor.DarkYellow);

            Console.Write("[3]");
            Menu.WriteLineInColor(" Zurück", ConsoleColor.Red);
            Console.WriteLine();

            Console.Write("[0]");
            Menu.WriteLineInColor(" Profil löschen", ConsoleColor.DarkRed);
            Console.WriteLine("--------------------------------------------------------");
            InputOption();
        }

        private void InputOption()
        {
            string input = "";
            Menu nextMenu;

            while(true)
            {
                
                Console.Write("Eingabe: ");
                input = Console.ReadLine().ToString();
                bool correctInput = true;

                switch(input)
                {
                    case "0":
                        nextMenu = new ConfirmProfileDeleteMenu();
                        break;

                    case "1":
                        ItemListMenuHelper.InitializePropertys(ItemListMenuHelper.ItemLists.PlantList);
                        nextMenu = new ItemListMainMenu();
                        break;

                    case "2":
                        ItemListMenuHelper.InitializePropertys(ItemListMenuHelper.ItemLists.GiftList);
                        nextMenu = new ItemListMainMenu();
                        break;

                    case "3":
                        nextMenu = new LoadProfileMenu();
                        break;

                    default:
                        correctInput = false;
                        Menu.WriteLineInColor("Fehler! Bitte mache eine gültige Eingabe.", ConsoleColor.Red);
                        Console.WriteLine();
                        break;
                }

                if (correctInput)
                {
                    break;
                }
            }
        }
    }
}
