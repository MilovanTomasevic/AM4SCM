using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFCalc.Model
{
    [Serializable]
    public class CalculationModel
    {
        public string ServiceName { get; set; }
        public List<FuzzyNumber> Calculations { get; set; }
        public List<AlphaSection> FuzzyCalculations { get; set; }
        //public List<double> Scores { get; set; }
        public Dictionary<string, FuzzyNumber> Scores { get; set; }
        public bool IsAlphaSection { get; set; }

        public CalculationModel(string name)
        {
            ServiceName = name;
            Calculations = new List<FuzzyNumber>();
            FuzzyCalculations = new List<AlphaSection>();
            //Scores = new List<double>();
            Scores = new Dictionary<string, FuzzyNumber>();
        }
    }
}
