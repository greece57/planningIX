using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planningIX
{
    class ListOfFactSheets<T>: List<hasUniqueName>
    {
        public object this[string name]
        {
            get 
            {
                return Array.Find<hasUniqueName>(this.ToArray(), data => (data.Name == name));
            }
        }
    }

    interface hasUniqueName
    {
        string Name { get; set; }
    }
}
