using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFCalc.Model
{
    [Serializable]
    public class WeightModel
    {
        public string Name { get; set; }
        public bool IsAlphaScore { get; set; }
        //public double Weight { get; set; }
        public double Weight
        {
            get
            {
                return FuzzyWeight.Middle;
            }
            set
            {
                FuzzyWeight.Middle = value;
                //Weight = value;
            }
        }
        //public Tuple<double, double, double> FuzzyWeight { get; set; }
        private FuzzyNumber _fuzzyWeight;
        public FuzzyNumber FuzzyWeight
        {
            get
            {
                return _fuzzyWeight = _fuzzyWeight ?? new FuzzyNumber();
            }
            set
            {
                _fuzzyWeight = value;
            }
        }
        public double Left {
            get
            {
                return FuzzyWeight.Left;
            }
            set
            {
                FuzzyWeight.Left = value;
            }
        }
        public double Middle {
            get
            {
                return FuzzyWeight.Middle;
            }
            set
            {
                FuzzyWeight.Middle = value;
                //Weight = value;
            }
        }
        public double Right
        {
            get
            {
                return FuzzyWeight.Right;
            }
            set
            {
                FuzzyWeight.Right = value;
            }
        }
    }
}
