using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geburtstags_Informant
{
    internal class ConfirmProfileDeleteMenu : Menu
    {
        public override void ShowDisplayMenu()
        {
            Console.Write("Bist du sicher das du [");
            Menu.WriteInColor($"{ProfileManager.CurrentProfile.FirstName} {ProfileManager.CurrentProfile.LastName}", ConsoleColor.Cyan);
            Console.Write("]");
            Menu.WriteInColor(" löschen", ConsoleColor.DarkRed);
            Console.WriteLine(" willst?");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine();
            Console.Write("[1]");
            Menu.WriteLineInColor(" Ja", ConsoleColor.DarkRed);
            Console.WriteLine("[2] Nein");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------");
            InputOption();
        }

        private void InputOption()
        {
            Menu nextMenu;
            bool correctInput = true;
            string input;
            while (true)
            {
                Console.Write("Eingabe: ");
                input = Console.ReadLine().ToString();
                switch (input)
                {
                    case "1":
                        ProfileManager.DeleteProfile(ProfileManager.CurrentProfile);
                        nextMenu = new StartMenu();
                        break;

                    case "2":
                        nextMenu = new ProfileMainMenu();
                        break;
                    default:
                        correctInput = false;
                        Menu.WriteLineInColor("Fehler! Bitte mache eine korrekte eingabe.", ConsoleColor.Red);
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
