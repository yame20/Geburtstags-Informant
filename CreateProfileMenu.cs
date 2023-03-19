using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Geburtstags_Informant
{
    internal class CreateProfileMenu : Menu
    {
        public override void ShowDisplayMenu()
        {
            Menu.WriteInColor("Profil", ConsoleColor.Cyan);
            Console.WriteLine(" erstellen");
            Menu.ShowCancelOption();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine();

            string firstName = InputFirstName();
            string lastName = InputLastName();
            ValidateIfExist(firstName, lastName);
            DateTime birthdayDate = InputBirthdayDate();

            CreateProfile(firstName, lastName, birthdayDate);
            
        }

        
        private string InputFirstName()
        {
            while (true)
            {
                Menu nextMenu;
                Menu.WriteInColor("Vorname", ConsoleColor.Cyan);
                Console.Write(": ");
                string firstName = Console.ReadLine().ToString();
                if (firstName != "cancel")
                {
                    if (ValidateNameOnChar(firstName))
                    {
                        return firstName;
                    }
                }
                else
                {
                    nextMenu = new StartMenu();
                }
            }
        }
        private string InputLastName()
        {
            while (true)
            {
                Menu nextMenu;
                Menu.WriteInColor("Nachname", ConsoleColor.Cyan);
                Console.Write(": ");
                string lastName = Console.ReadLine().ToString();
                if (lastName != "cancel")
                {
                    if (ValidateNameOnChar(lastName))
                    {
                        return lastName;
                    }
                }
                else
                {
                    nextMenu = new StartMenu();
                }
            }
        }
        private bool ValidateNameOnChar(string name)
        {
            foreach(char c in name)
            {
                if(!char.IsLetter(c))
                {
                    Menu.WriteLineInColor("Fehler! Ungültige Zeicheneingabe!", ConsoleColor.Red);
                    Console.WriteLine();
                    return false;
                }
            }
            return true;
        }

        private void ValidateIfExist(string firstName, string lastName)
        {
            
            if (ProfileManager.CheckIfProfileExists(firstName, lastName))
            {
                Menu.WriteLineInColor("Fehler! Profil existiert bereits!", ConsoleColor.Red);
                Console.WriteLine();
                Console.Write("Drücken sie eine beliebige Taste... ");
                Console.ReadKey();
                Menu nextMenu = new CreateProfileMenu();
            }
            
                
        }

        private DateTime InputBirthdayDate()
        {
            while (true)
            {
                Menu nextMenu;
                Menu.WriteInColor("Geburtsdatum (TT.MM.JJJJ): ", ConsoleColor.Magenta);
                try
                {
                    string birthdayDateString = Console.ReadLine().ToString();
                    if (birthdayDateString == "cancel")
                    {
                        nextMenu = new StartMenu();
                    }
                        DateTime birthdayDate = DateTime.Parse(birthdayDateString);

                        return birthdayDate;
                }

                catch (Exception)
                {
                    Menu.WriteLineInColor("Fehler! Bitte gebe das Jahr wie angegeben ein.", ConsoleColor.Red);
                    Console.WriteLine();
                }  
            }
        }
        private void CreateProfile(string firstName, string lastName, DateTime birthdayDate)
        {
            ProfileManager.CreateProfile(firstName, lastName, birthdayDate);
            Menu.WriteLineInColor("Das Profil wurde angelegt!", ConsoleColor.Green);
            Console.WriteLine();
            Console.Write("Drücken sie eine beliebige Taste... ");
            Console.ReadKey();
            Menu nextMenu = new StartMenu();
        }
    }
}
