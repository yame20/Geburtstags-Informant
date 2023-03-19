using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Geburtstags_Informant
{
    [Serializable]
    internal class Profile
        
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthdayDate { get; set; }
        public List<IItem> FavouritPlants { get; private set; }
        public List<IItem> GiftedList { get; private set; }

        public Profile(string firstName, string lastName, DateTime birthdayDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthdayDate = birthdayDate;
            FavouritPlants = new List<IItem>();
            GiftedList = new List<IItem>();
            
        }

        public void ItemToList(IItem item)
        {  
            ItemListMenuHelper.SelectedList.Add(item);
            ProfileManager.SaveProfile(this);
        }

        public void RemoveItemFromList(IItem item, List<IItem> selectedList)
        {
            selectedList.Remove(item);
            ProfileManager.SaveProfile(this);
        }
        
        public void ShowItemsOnDisplay()
        {
            var sortList = from item in ItemListMenuHelper.SelectedList
                           orderby item.Year
                           select item; 

            foreach (IItem item in sortList)
            {
                Menu.WriteLineInColor(item.ToString(), ItemListMenuHelper.ItemColor);
            }
        }   
    }
}
