using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeanIX.Api.Models;

namespace planningIX
{
    class Component : hasUniqueNameAndCurrentVersions
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
        public List<string> currentVersions {get; private set;}
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

        public List<Application> applicationList;

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
        public string StandardisationTag
        {
            get
            {
                if (String.IsNullOrEmpty(standardTechnology))
                    return standardTechnology;
                else if (standardTechnology.Equals("Global"))
                    return "Global standard";
                else if (standardTechnology.Equals("Local"))
                    return "Local standard";
                else if (standardTechnology.Equals("No"))
                    return "Not standard";
                else if (standardTechnology.Equals("Phase-out"))
                    return "PhaseOut standard";
                else if (standardTechnology.Equals("Yes"))
                    return "Standard";
                else
                    throw new Exception(string.Concat(standardTechnology, " of component ", name, " does not has a Standardisation-Tag"));
            }
        }
        public string DecisionStatusTag
        {
            get
            {
                if (decisionStatus.Equals("None"))
                    return null;
                else
                    return decisionStatus;
            }
        }
        //public string DomainTag
        //{
        //    get
        //    {
        //        return domain.Replace(",", "");
        //    }
        //}


        public Component()
        {
            currentVersions = new List<string>();
            applicationList = new List<Application>();
        }

        public override string ToString()
        {
            return ("Component {Name: " + Name + " Release: " + release + " Alias: " + alias + "}");
        }

        internal Resource getResource()
        {
            Resource resource = new Resource();
            resource.name = Name;
            resource.alias = alias;
            resource.description = descriptionOfVersions;
            resource.release = release;
            resource.tags.Add(domain);
            resource.tags.Add(StandardisationTag);
            resource.tags.Add(DecisionStatusTag);

            // Remove wrong tags
            resource.tags.RemoveAll(tag => tag == null);

            for (int i = 0; i < resource.tags.Count; i++)
            {
                resource.tags[i] = TagCleaner.cleanTag(resource.tags[i]);
            }

            return resource;
        }

        internal void addComponentLifecycleToService(Resource resource)
        {
            FactSheetHasLifecycle serviceStartLifecycle = new FactSheetHasLifecycle();
            FactSheetHasLifecycle serviceEndLifecycle = new FactSheetHasLifecycle();
            serviceStartLifecycle.factSheetID = ID;
            serviceStartLifecycle.lifecycleStateID = "3";
            serviceStartLifecycle.startDate = startDateString;
            serviceEndLifecycle.factSheetID = ID;
            serviceEndLifecycle.lifecycleStateID = "5";
            serviceEndLifecycle.startDate = endDateString;

            if (resource.factSheetHasLifecycles == null) resource.factSheetHasLifecycles = new List<FactSheetHasLifecycle>();
            resource.factSheetHasLifecycles.Add(serviceStartLifecycle);
            resource.factSheetHasLifecycles.Add(serviceEndLifecycle);
        }
    }
}
