using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Geburtstags_Informant
{
    abstract class Menu
    {
        public Menu()
        {
            Console.Title = "Geburtstags - Informant";
            Console.WindowWidth = 56;
            Console.Clear();
            ShowDisplayMenu();
        }
        
        public abstract void ShowDisplayMenu();

        public static void ShowCancelOption()
        {
            Menu.WriteInColor("[\"cancel\"] ", ConsoleColor.Red);
            Console.Write("zum Abbrechen ");
            Console.WriteLine();
        }
        
        public static void WriteInColor(string text, System.ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
        public static void WriteLineInColor(string text, System.ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }    
    }
}
