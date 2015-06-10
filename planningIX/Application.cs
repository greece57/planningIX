using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planningIX
{
    class Application
    {
        public string name;
        public List<string> currentVersions;
        public string state;
        public string alias;
        public string itServiceCenter;
        public string itProductGroup;
        public string productSpecialist;
        public string startDate;
        public string endDate;
        public string itProductCategory;
        public string usage;
        public string standardisation;
        public string description;

        public string responsible {
            get
            {
                string _responsible = productSpecialist.Replace(" ", ".");
                _responsible = String.Concat(_responsible, "@mre.tum");
                return _responsible;
            }
        }
        public string release
        {
            get
            {
                string _release = "";
                foreach (string version in currentVersions)
                {
                    if (version.Contains(name))
                    {
                        _release = version.Replace(name, "").Trim();
                    }
                }
                return _release;
            }
        }
        public string descriptionWithVersions {
            get
            {
                // There is only 1 current Version and the number is already in Release
                if (currentVersions.Count <= 1 && !String.IsNullOrEmpty(release))
                {
                    return description;
                }
                else // store the versions in the description
                {
                    string newDescription = description + Environment.NewLine + "Versions:";
                    foreach (string currentVersion in currentVersions)
                    {
                        newDescription += Environment.NewLine + currentVersion;
                    }
                    return newDescription;
                }
            }
        }

        public Application()
        {
            currentVersions = new List<string>();
        }

        public override string ToString()
        {
            return ("Name: " + name + " Release: " + release + " Alias: " + alias);
        }

    }
}
