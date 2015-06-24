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

        public partial class InterfacesFile
        {
            public const string WORKSHEET_NAME = "Export";
            public const int FIRST_ROW = 4;
            public enum Columns : int
            {
                nr = 1, from, typeFrom, itServiceCenterFrom, productSpecialistFrom, to, typeTo, itServiceCenterTo, productSpecialistTo,
                state, start, end, description, connectionType, connectionMethod, connectionFrequency, connectionDataFormat,
                personalData, transferredBusinessObjects
            }
        }

        public partial class ComponentsFile
        {
            public const string WORKSHEET_NAME = "Export";
            public const int FIRST_ROW = 3;
            public enum Columns : int
            {
                nr = 1, name, domain, standardTechnology, decisionStatus, state, itServiceCenter,
                alias, itProductGroup, productSpecialist, startDate, endDate
            }
        }

        public partial class ComponentsUsageFile
        {
            public const string WORKSHEET_NAME = "Export";
            public const int FIRST_ROW = 3;
            public enum Columns : int
            {
                nr = 1, id, componentVersion, itServiceCenter, componentVersionStartDate, componentVersionEndDate,
                componentVersionState, compLifecycleState, usedInVersion, usedInName, usedItServiceCenter, usedItProductGroup,
                usedProductSpecialist, usedProductSpecialistEmail, usedStartDate, usedEndDate, usedVersionState, usedLifecycleState
            }
        }

        public partial class BusinessSupportFile
        {
            public const string WORKSHEET_NAME = "Export";
            public const int FIRST_ROW = 3;
            public enum Columns : int
            {
                nr = 1, businessProcessLvl1 = 8, applicationName = 12
            }
        }

    }
}
