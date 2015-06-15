using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planningIX
{
    class ListOfApplications: List<Application>
    {
        public object this[string name]
        {
            get 
            {
                return Array.Find<Application>(this.ToArray(), app => (app.Name == name));
            }
        }

        public Application getByCurrentVersionName(string currentVersionName)
        {
            return Array.Find<Application>(this.ToArray(), app => (app.currentVersionName == currentVersionName));
        }
    }
}
