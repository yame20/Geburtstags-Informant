using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Geburtstags_Informant
{
    internal static class ProfileManager
    {
        public static Profile CurrentProfile { get; set; }
    
        
        public static void CreateProfile(string firstName, string lastName, DateTime birthdayDate)
        {
            CurrentProfile = new Profile(firstName, lastName, birthdayDate);
            SaveProfile(CurrentProfile);  
        }

        public static bool CheckIfProfileExists(string firstName, string lastName)
        {
            string filePath = AppContext.BaseDirectory + firstName + " " + lastName + ".prof";

            return File.Exists(filePath);
        }
        

        public static void SaveProfile(Profile profile)
        {
            string filePath = AppContext.BaseDirectory + profile.FirstName + " " + profile.LastName + ".prof";
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    binaryFormatter.Serialize(stream, profile);
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Menu.WriteLineInColor(ex.ToString(), ConsoleColor.Red);
                Console.ReadKey();
            }
        }

        public static void LoadProfile(string profilePath)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            try
            {
                using(FileStream stream = new FileStream(profilePath, FileMode.Open))
                {
                    CurrentProfile = (Profile)binaryFormatter.Deserialize(stream);
                }

            }
            catch (Exception ex)
            {
                Console.Clear();
                Menu.WriteLineInColor(ex.ToString(), ConsoleColor.Red);
                Console.ReadKey();
            }
        }
        public static void DeleteProfile(Profile profile)
        {
            string profilePath = AppContext.BaseDirectory + profile.FirstName + " " + profile.LastName + ".prof";
            File.Delete(profilePath);
            
        }
        public static int ShowAgeInYears()
        {
            int alter = DateTime.Now.Year - ProfileManager.CurrentProfile.BirthdayDate.Year;
            if (ProfileManager.CurrentProfile.BirthdayDate.Month > DateTime.Now.Month ||
                DateTime.Now.Month == ProfileManager.CurrentProfile.BirthdayDate.Month && DateTime.Now.Day < ProfileManager.CurrentProfile.BirthdayDate.Day)
            {
                alter--;
            }

            return alter;
        }
    }
}
