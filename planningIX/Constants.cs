using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planningIX
{
    class Constants
    {
        public partial class LeanIX
        {
            public const string BASE_PATH = "https://app.leanix.net/MRE2TUM/api/v1";
            public const string API_KEY = "2754f33e5300cf58c9fb2bb0362b4b35";
        }

        public partial class ComplienceReportFile
        {
            public const string WORKSHEET_NAME = "Export";
            public const int FIRST_ROW = 4;
            public enum Columns : int
            {
                nr = 1, name, description, itServiceCenter, itProductGroup, productSpecialist,
                businessContact, applicationType, state, csRelevance, drClass, confProd, confInt,
                confDev, integrity, availability, nrOfLegalEntities, nrOfBusinessProcesses, nrOfInterfaces
            }
        }

        public partial class ApplicationsFile
        {
            public const string WORKSHEET_NAME = "Export";
            public const int FIRST_ROW = 3;
            public enum Columns : int
            {
                nr = 1, name, state, alias, itServiceCenter, itProductGroup, productSpecialist, 
                startDate, endDate, itProductCategory, usage, standardisation, description
            }
        }

    }
}
