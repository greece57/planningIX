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
        public ListOfFactSheets<BusinessProcessLvl1> lvl1BusinessProcessList;
        public ListOfFactSheets<Organisation> organisationList;

        public ImportedData()
        {
            applicationList = new ListOfFactSheets<Application>();
            componentList = new ListOfFactSheets<Component>();
            lvl1BusinessProcessList = new ListOfFactSheets<BusinessProcessLvl1>();
            organisationList = new ListOfFactSheets<Organisation>();
        }
    }
}
