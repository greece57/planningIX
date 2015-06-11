using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planningIX
{
    struct Progress
    {
        public float current;
        public float max;

        public double progress
        {
            get
            {
                return (current / max);
            }
        }

        public override string ToString()
        {
            return String.Format(System.Globalization.CultureInfo.InvariantCulture, 
                                "{0:#0.##%}", progress);
        }
    }
}
