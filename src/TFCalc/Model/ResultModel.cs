using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFCalc.Model
{
    public class ResultModel
    {
        /// <summary>
        /// Key is the combination of R-s used in calculation
        /// </summary>
        public Dictionary<string, AlphaSection> FuzzyResult { get; set; }
        /// <summary>
        /// Key is the combination of R-s used in calculation
        /// </summary>
        public Dictionary<string, FuzzyNumber> KripsResult { get; set; }
    }
}
