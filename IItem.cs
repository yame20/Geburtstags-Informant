using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geburtstags_Informant
{
    internal interface IItem
    {
        string Name { get; set; }
        int Year { get; set; }

        string ToString();
    }
}