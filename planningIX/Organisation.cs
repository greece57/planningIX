using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planningIX
{
    class Organisation : hasUniqueNameAndCurrentVersions
    {
        public string ID;
        public string Name { get; set; }

        public List<string> currentVersions { get; private set; }

        public List<Application> applicationList;

        public Organisation()
        {
            currentVersions = new List<string>();
            applicationList = new List<Application>();
        }
    }
}
