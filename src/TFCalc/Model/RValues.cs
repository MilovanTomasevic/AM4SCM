using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFCalc.Model
{
    [Serializable]
    public class RValues
    {
        public bool IsSelected { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public double Value
        {
            get
            {
                return PValue;
            }
            set
            {
                PValue = value;
            }
        }
        public double PValue { get; set; }
        public double QValue { get; set; }
    }
}
