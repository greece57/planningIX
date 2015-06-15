using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planningIX
{
    class ImportedData
    {
        public ListOfFactSheets<Application> applicationList;
        public ListOfFactSheets<Component> componentList;

        public ImportedData()
        {
            applicationList = new ListOfFactSheets<Application>();
            componentList = new ListOfFactSheets<Component>();
        }
    }
}
