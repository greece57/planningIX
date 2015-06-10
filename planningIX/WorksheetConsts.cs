using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planningIX
{
    class WorksheetConsts
    {
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
