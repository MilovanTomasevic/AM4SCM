using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFCalc.Model
{
    [Serializable]
    public class ServiceModel
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
    }
}
