using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCalc.Model;

namespace TFCalc
{
    [Serializable]
    public enum ScoreGrain
    {
        Coarse,
        Fine
    }

    [Serializable]
    public class Settings
    {
        public ScoreGrain Grain { get; set; }
        public BindingList<Score> Scores { get; set; }

        public void LoadCoarseDefault()
        {
            if (Scores == null)
                Scores = new BindingList<Score>();
            Scores.Clear();
            for (int i = 1; i <= 5; i++)
            {
                Scores.Add(new Score
                {
                    Name = i.ToString(),
                    Value = Math.Round(i * 0.2, 2)
                });
            }
        }

        public void LoadFineDefault()
        {
            if (Scores == null)
                Scores = new BindingList<Score>();
            Scores.Clear();
            for (int i = 1; i <= 10; i++)
            {
                Scores.Add(new Score
                {
                    Name = i.ToString(),
                    Value = Math.Round(i * 0.1, 2)
                });
            }
        }
    }
}
