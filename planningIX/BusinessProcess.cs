using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planningIX
{
    class BusinessProcessLvl1 : hasUniqueNameAndCurrentVersions
    {
        public string ID;
        public string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public List<string> currentVersions { get; private set; }

        public List<Application> applicationList;

        public BusinessProcessLvl1()
        {
            currentVersions = new List<string>();
            applicationList = new List<Application>();
        }
    }
}
