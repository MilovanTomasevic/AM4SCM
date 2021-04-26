using System;
using System.Collections.Generic;
using System.ComponentModel;
using TFCalc.Enum;

namespace TFCalc.Model
{
    [Serializable]
    public class DataHolder
    {
        public Settings Settings { get; set; }
        public BindingList<RValues> RList { get; set; }
        public BindingList<WeightModel> WeightList { get; set; }
        public Dictionary<string, BindingList<WeightModel>> WeightGroups { get; set; }
        public BindingList<ServiceModel> ServicesList { get; set; }
        public Dictionary<string, CalculationModel> Calculations { get; set; }
        public NumberType WeightType;
        public NumberType ScoreType;
        public FormulaType FormulaType;
        public Dictionary<string, GroupData> Groups;
        public double Alpha { get; set; }
    }
}
