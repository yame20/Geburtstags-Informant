using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geburtstags_Informant
{
    [Serializable]
    internal class Plant : IItem
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public Plant(string name)
        {
            Name = name;
            Year = 0;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
