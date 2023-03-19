using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geburtstags_Informant
{
    internal class StartMenu : Menu
    {
        public override void ShowDisplayMenu()
        {
            Console.WriteLine("      Wilkommen beim Geburtstags-Informanten. ");
            Console.WriteLine("Ich habe die Informantionen, die DU vergessen hast. :P");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Wähle eine Aktion aus: ");
            Console.WriteLine();

            Console.Write("[1] Wähle ein");
            Menu.WriteLineInColor(" Profil", ConsoleColor.Cyan);

            Console.Write("[2]");
            Menu.WriteInColor(" Profil", ConsoleColor.Cyan);
            Console.WriteLine(" erstellen");

            Console.Write("[3]");
            Menu.WriteLineInColor(" Programm beenden", ConsoleColor.Red);

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
            InputOption();
        }

        private void InputOption()
        {
            string input;
            Menu nextMenu;
            while (true)
            {
                Console.Write("Eingabe: ");
                input = Console.ReadLine().ToString();
                bool correctInput = true;

                switch (input)
                {
                    case "1":
                        nextMenu = new LoadProfileMenu();
                        break;

                    case "2":
                        nextMenu = new CreateProfileMenu();
                        break;

                    case "3":
                        Environment.Exit(0);
                        return;

                    default:
                        correctInput = false;
                        Menu.WriteLineInColor("Fehler! Bitte wähle eine angegbene Aktion aus.", ConsoleColor.Red);
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
