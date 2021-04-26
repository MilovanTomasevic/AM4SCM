using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFCalc.Model
{
    [Serializable]
    public class ScoringDataModel
    {
        public string WeightName { get; set; }
        public BindingList<double> ServicesScore { get; set; }
        public string Score = "0.1";
    }
}
