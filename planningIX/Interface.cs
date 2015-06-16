using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planningIX
{
    class Interface
    {
        public string ID;
        public string from;
        public string to;
        public Application toApp;
        public string state;
        public DateTime startDate;
        public DateTime endDate;
        public string description;
        public string connectionType;
        public string connectionMethod;
        public string connectionFrequency;
        public string dataFormat;
        public string personalData;
        public string transferredBuisnessObjects;

        public string Description
        {
            get
            {
                string _description = "";//description.Replace("<", "").Replace(">", "");
                if ((connectionFrequency??"").Equals("Quarterly"))
                {
                    _description += Environment.NewLine + "Frequency Quarterly!";
                }
                return _description;
            }
        }
        public string Frequency
        {
            get
            {
                if (String.IsNullOrEmpty(connectionFrequency))
                {
                    return "";
                }
                else if (connectionFrequency.Equals("On Demand")){
                    return "7";
                }
                else if (connectionFrequency.Equals("Realtime")) {
                    return "6";
                }
                else if (connectionFrequency.Equals("Yearly"))
                {
                    return "5";
                }
                else if (connectionFrequency.Equals("Monthly") || connectionFrequency.Equals("Quarterly"))
                {
                    return "4";
                }
                else if (connectionFrequency.Equals("Weekly"))
                {
                    return "3";
                }
                else if (connectionFrequency.Equals("Daily"))
                {
                    return "2";
                }
                else if (connectionFrequency.Equals("Hourly"))
                {
                    return "1";
                }
                else
                {
                    return "";
                }
            }
        }
        public string InterfaceType
        {
            get
            {
                if (String.IsNullOrEmpty(connectionFrequency))
                {
                    return "";
                }
                else if (connectionFrequency.Equals("automatic"))
                {
                    return "1";
                }
                else if (connectionFrequency.Equals("manual triggered"))
                {
                    return "3";
                }
                else
                {
                    return "";
                }
            }
        }
        public string State
        {
            get
            {
                if (String.IsNullOrEmpty(state))
                {
                    return "";
                }
                else if (state.Equals("Active"))
                {
                    return "1";
                }
                else if (state.Equals("Plan"))
                {
                    return "2";
                }
                else if (state.Equals("Retired"))
                {
                    return "3";
                }
                else
                {
                    return "";
                }
            }
        }

        public override string ToString()
        {
            return String.Concat("Interface { To: ", toApp , "}");
        }

    }
}
