using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeanIX.Api.Models;

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


        public DateTime startDate;
        public DateTime endDate;


        public List<string> currentVersions { get; private set; }

        public List<Application> applicationList;

        public BusinessProcessLvl1()
        {
            currentVersions = new List<string>();
            applicationList = new List<Application>();
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

        public void addBusinessProcessLifecycleToBusinessCapability(BusinessCapability businessCapability)
        {
            FactSheetHasLifecycle bCStartLifecycle = new FactSheetHasLifecycle();
            FactSheetHasLifecycle bCEndLifecycle = new FactSheetHasLifecycle();
            bCStartLifecycle.factSheetID = ID;
            bCStartLifecycle.lifecycleStateID = "3";
            bCStartLifecycle.startDate = startDateString;
            bCEndLifecycle.factSheetID = ID;
            bCEndLifecycle.lifecycleStateID = "5";
            bCEndLifecycle.startDate = endDateString;

            if (businessCapability.factSheetHasLifecycles == null) businessCapability.factSheetHasLifecycles = new List<FactSheetHasLifecycle>();
            businessCapability.factSheetHasLifecycles.Add(bCStartLifecycle);
            businessCapability.factSheetHasLifecycles.Add(bCEndLifecycle);
        }
    }
}
