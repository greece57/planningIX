using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planningIX
{
    class ImportedData
    {
        public ListOfNamedObjects<Application> applicationList;
        public ListOfNamedObjects<Component> componentList;

        public ImportedData()
        {
            applicationList = new ListOfNamedObjects<Application>();
            componentList = new ListOfNamedObjects<Component>();
        }
    }
}
