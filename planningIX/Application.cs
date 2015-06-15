using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeanIX.Api.Models;

namespace planningIX
{
    class Application : hasUniqueName
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
        public string Description
        {
            get
            {
                if (description == null) return description;
                string _description = description;
                _description = _description.Replace("<", " ");
                _description = _description.Replace(">", " ");
                return _description;
            }
            set { description = value; }
        }
        public List<string> currentVersions;
        public string state;
        public string alias;
        public string itServiceCenter;
        public string itProductGroup;
        public string productSpecialist;
        public DateTime startDate;
        public DateTime endDate;
        public string itProductCategory;
        public string usage;
        public string standardisation;
        public string businessContact;
        public string applicationType;
        public string CS_Relevance
        {
            get
            {
                if (cs_Relevance == null)
                {
                    return cs_Relevance;
                }
                else if (cs_Relevance.Equals("yes"))
                {
                    return "CS Relevant";
                }
                else if (cs_Relevance.Equals("no"))
                {
                    return "not CS Relevant";
                }
                else
                {
                    return cs_Relevance;
                }
            }
            set { cs_Relevance = value; }
        }
        public string DR_Class
        {
            get
            {
                if (dr_class == null)
                {
                    return null;
                }
                else if (dr_class.Equals("none"))
                    return null;
                else
                    return dr_class;
            }
            set { dr_class = value; }
        }
        public string ConfProd
        {
            get
            {
                if (confProd == null)
                    return confProd;
                else if (confProd.Contains("C0"))
                    return "C0 prod";
                else if (confProd.Contains("C1"))
                    return "C1 prod";
                else if (confProd.Contains("C2"))
                    return "C2 prod";
                else if (confProd.Contains("C3"))
                    return "C3 prod";
                else if (confProd.Contains("C4"))
                    return "C4 prod";
                else
                    return null;
            }
            set { confProd = value; }
        }
        public string ConfInt
        {
            get
            {
                if (confInt == null)
                    return confInt;
                else if (confInt.Contains("C0"))
                    return "C0 int";
                else if (confInt.Contains("C1"))
                    return "C1 int";
                else if (confInt.Contains("C2"))
                    return "C2 int";
                else if (confInt.Contains("C3"))
                    return "C3 int";
                else if (confInt.Contains("C4"))
                    return "C4 int";
                else
                    return null;
            }
            set { confInt = value; }
        }
        public string ConfDev
        {
            get
            {
                if (confDev == null)
                    return confDev;
                else if (confDev.Contains("C0"))
                    return "C0 dev";
                else if (confDev.Contains("C1"))
                    return "C1 dev";
                else if (confDev.Contains("C2"))
                    return "C2 dev";
                else if (confDev.Contains("C3"))
                    return "C3 dev";
                else if (confDev.Contains("C4"))
                    return "C4 dev";
                else
                    return null;
            }
            set { confDev = value; }
        }
        public string Integrity
        {
            get
            {
                if (integrity == null)
                    return integrity;
                else if (integrity.Contains("I1"))
                    return "I1";
                else if (integrity.Contains("I2"))
                    return "I2";
                else if (integrity.Contains("I3"))
                    return "I3";
                else if (integrity.Contains("I4"))
                    return "I4";
                else
                    return null;
            }
            set { integrity = value; }
        }
        public string Availability
        {
            get
            {
                if (availability == null)
                    return availability;
                else if (availability.Contains("A1"))
                    return "A1";
                else if (availability.Contains("A2"))
                    return "A2";
                else if (availability.Contains("A3"))
                    return "A3";
                else if (availability.Contains("A4"))
                    return "A4";
                else
                    return null;
            }
            set { availability = value; }
        }

        public int nrOfLegalEntities;
        public int nrOfBusinessProcesses;
        public int nrOfInterfaces;

        
        public string responsible {
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

        private string name;
        private string description;
        private string cs_Relevance;
        private string dr_class;
        private string confProd;
        private string confInt;
        private string confDev;
        private string integrity;
        private string availability;

        public Application()
        {
            currentVersions = new List<string>();
        }

        public override string ToString()
        {
            return ("Application {Name: " + Name + " Release: " + release + " Alias: " + alias + "}");
        }

        public Service getService()
        {
            Service service = new Service();
            service.name = Name;
            service.alias = alias;
            service.description = descriptionWithVersions;
            service.release = release;
            service.tags.Add(usage);
            service.tags.Add(standardisation);
            service.tags.Add(applicationType);
            service.tags.Add(CS_Relevance);
            service.tags.Add(DR_Class);
            service.tags.Add(ConfProd);
            service.tags.Add(ConfDev);
            service.tags.Add(ConfInt);
            service.tags.Add(Integrity);
            service.tags.Add(Availability);

            // Remove wrong tags
            service.tags.RemoveAll(tag => tag == null);
            foreach (string tag in service.tags)
            {
                TagCleaner.cleanTag(tag);
            }


            return service;
        }

        public void addApplicationLifecycleToService(Service service)
        {
            FactSheetHasLifecycle serviceStartLifecycle = new FactSheetHasLifecycle();
            FactSheetHasLifecycle serviceEndLifecycle = new FactSheetHasLifecycle();
            serviceStartLifecycle.factSheetID = ID;
            serviceStartLifecycle.lifecycleStateID = "3";
            serviceStartLifecycle.startDate = startDateString;
            serviceEndLifecycle.factSheetID = ID;
            serviceEndLifecycle.lifecycleStateID = "5";
            serviceEndLifecycle.startDate = endDateString;

            if (service.factSheetHasLifecycles == null) service.factSheetHasLifecycles = new List<FactSheetHasLifecycle>();
            service.factSheetHasLifecycles.Add(serviceStartLifecycle);
            service.factSheetHasLifecycles.Add(serviceEndLifecycle);
        }

    }
}
