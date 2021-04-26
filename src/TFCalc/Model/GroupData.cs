using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCalc.Enum;

namespace TFCalc.Model
{
    [Serializable]
    public class GroupData
    {
        public string Name { get; set; }
        public bool IsMainGroup { get { return Name.Equals(Const.MainGroupName); } }
        public BindingList<WeightModel> Weights { get; set; }
        public BindingList<RValues> RList { get; set; }
        public NumberType WeightType { get; set; }
        public NumberType ScoreType { get; set; }
        /// <summary>
        /// Key is the service name
        /// </summary>
        public Dictionary<string, ServiceData> Services { get; set; }

        public GroupData(string name)
        {
            Name = name;
            Weights = new BindingList<WeightModel>();
            //RList = new BindingList<RValues>();
            RList = Tools.GetNewRTable();
            Services = new Dictionary<string, ServiceData>();
        }
    }
}
