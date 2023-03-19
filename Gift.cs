using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Geburtstags_Informant
{
    [Serializable]
    internal class Gift : IItem
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public Gift (string giftName, int year)
        {
            Name = giftName;
            Year = year;
            
        }

        public override string ToString()
        {
            return $"{Name} verschenkt im Jahr {Year}";
        }
    }
}
