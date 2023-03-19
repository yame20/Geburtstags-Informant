using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geburtstags_Informant
{
    internal class LoadProfileMenu : Menu
    {
        public override void ShowDisplayMenu()
        {
            Console.Write("Wähle ein");
            Menu.WriteInColor(" Profil", ConsoleColor.Cyan);
            Console.WriteLine(" aus ");
            Menu.ShowCancelOption();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine();
            ShowProfiles();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine();
            string choosenProfile = ChooseProfile();
            if (choosenProfile != "cancel")
            {
                ProfileManager.LoadProfile(choosenProfile);
                Menu nextMenu = new ProfileMainMenu();
            }
            else
            {
                Menu nextMenu = new StartMenu();
            }
            
        }

        private void ShowProfiles()
        {
            string[] profileFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.prof");
            if (profileFiles.Length != 0)
            {
                foreach (string file in profileFiles)
                {
                    Console.Write("-");
                    Menu.WriteLineInColor($" {Path.GetFileNameWithoutExtension(file)}", ConsoleColor.Cyan);
                }
            }
            else
            {
                Console.Write("Keine");
                Menu.WriteInColor(" Profile", ConsoleColor.Cyan);
                Console.WriteLine(" vorhanden");
                Console.Write("Erstelle zuerst ein");
                Menu.WriteInColor(" Profil", ConsoleColor.Cyan);
                Console.WriteLine("...");
            }
        }

        private string ChooseProfile()
        {
            string input = "";

            while(true)
            {
                Console.Write("Zu ladendes");
                Menu.WriteInColor(" Profil", ConsoleColor.Cyan);
                Console.Write(": ");
                input = Console.ReadLine();

                string[] profileFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.prof");
                bool correctInput = false;

                if (input == "cancel")
                {
                    correctInput = true;
                }
                else
                {
                    input += ".prof";
                    for (int i = 0; i < profileFiles.Length; i++)
                    {
                        profileFiles[i] = Path.GetFileName(profileFiles[i]);
                        if (input == profileFiles[i])
                        {
                            correctInput = true;
                            input = AppContext.BaseDirectory + input;
                            break;
                        }
                        
                    }
                }
                if (correctInput)
                {
                    break;
                }
                else
                {
                    Menu.WriteLineInColor("Fehler! Ungültiges Profil.", ConsoleColor.Red);
                    Console.WriteLine();
                }
            }
            return input;
        }
    }
}
