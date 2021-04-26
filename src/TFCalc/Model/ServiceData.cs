using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFCalc.Model
{
    [Serializable]
    public class ServiceData
    {
        public string ServiceKey { get; set; }
        public bool IsAlphaSection { get; set; }
        //public bool IsAlphaScore { get; set; }
        /// <summary>
        /// Key is the display name of the R used
        /// </summary>
        public Dictionary<string, AlphaSection> FuzzyCalculations { get; set; }
        /// <summary>
        /// Key is the display name of the R used
        /// </summary>
        public Dictionary<string, FuzzyNumber> KrispCalculation { get; set; }
        /// <summary>
        /// Key is the weight name
        /// </summary>
        public Dictionary<string, FuzzyNumber> Score { get; set; }

        public Dictionary<string, AlphaSection> FuzzyScore { get; set; }

        public ServiceData(string name)
        {
            ServiceKey = name;
            FuzzyCalculations = new Dictionary<string, AlphaSection>();
            KrispCalculation = new Dictionary<string, FuzzyNumber>();
            Score = new Dictionary<string, FuzzyNumber>();
            FuzzyScore = new Dictionary<string, AlphaSection>();
        }
    }
}
