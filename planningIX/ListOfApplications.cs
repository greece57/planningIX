using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planningIX
{
    class ListOfFactSheets<T>: List<hasUniqueNameAndCurrentVersions>
    {
        public object this[string name]
        {
            get 
            {
                return Array.Find<hasUniqueNameAndCurrentVersions>(this.ToArray(), data => (data.Name == name));
            }
        }

        internal T getByCurrentVersion(string currentVersion)
        {
            foreach (hasUniqueNameAndCurrentVersions factSheet in this)
            {
                if (factSheet.currentVersions.Contains(currentVersion))
                    return (T)factSheet;
            }
            return default(T);
        }
    }

    interface hasUniqueNameAndCurrentVersions
    {
        string Name { get; set; }
        List<string> currentVersions { get; }
    }
}
