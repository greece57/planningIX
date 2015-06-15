using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planningIX
{
    class Component : hasUniqueName
    {
        public string ID;
        public string Name
        {
            get
            {
                if (name == null) return null;
                string _name = name;
                _name = _name.Replace("<", "");
                _name = _name.Replace(">", "");
                return _name;
            }
            set
            { name = value; }
        }
        public List<string> currentVersions;
        public string state;
        public string alias;
        public string domain;
        public string standardTechnology;
        public string decisionStatus;
        public string itServiceCenter;
        public string itProductGroup;
        public string productSpecialist;
        public DateTime startDate;
        public DateTime endDate;

        private string name;


        public string responsible
        {
            get
            {
                if (String.IsNullOrEmpty(productSpecialist)) return productSpecialist;

                string _responsible = productSpecialist.Replace(" ", ".");
                _responsible = _responsible.Replace("ä", "ae");
                _responsible = _responsible.Replace("ö", "oe");
                _responsible = _responsible.Replace("ü", "ue");
                _responsible = _responsible.Replace("é", "e");
                _responsible = _responsible.Normalize();
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
                    if (version.Contains(Name))
                    {
                        _release = version.Replace(Name, "").Trim();
                    }
                }
                _release = _release.Replace("<", "");
                _release = _release.Replace(">", "");
                return _release;
            }
        }
        public string descriptionOfVersions
        {
            get
            {
                string newDescription = "Versions:";
                foreach (string currentVersion in currentVersions)
                {
                    newDescription += Environment.NewLine + currentVersion;
                }
                return newDescription;
            }
        }
        public string startDateString
        {
            get
            {
                return startDate.Year.ToString() + "-" + startDate.Month.ToString() + "-" + startDate.Day.ToString();
            }
        }
        public string endDateString
        {
            get
            {
                return endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString();
            }
        }


        public Component()
        {
            currentVersions = new List<string>();
        }

        public override string ToString()
        {
            return ("Component {Name: " + Name + " Release: " + release + " Alias: " + alias + "}");
        }
    }
}
