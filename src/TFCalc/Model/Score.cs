using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFCalc.Model
{
    [Serializable]
    public class Score
    {
        public string Name { get; set; }
        public double Value { get; set; }
        //public string SettingsGrainLevel { get { return Name; } set { Name = value; } }
        //public double SettingsGrainValue { get { return Value; } set { Value = value; } }
    }
}
