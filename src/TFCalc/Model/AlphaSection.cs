using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFCalc.Model
{
    [Serializable]
    public class AlphaSection
    {
        public const double defaultAlphaValue = 0.9;

        public static double _alphaValue = -1;
        public static double AlphaValue
        {
            get
            {
                if (_alphaValue > 0)
                {
                    return _alphaValue;
                }
                else
                {
                    return defaultAlphaValue;
                }
            }
            set
            {
                _alphaValue = value;
            }
        }

        public double Start { get; set; }
        public double End { get; set; }

        public AlphaSection(double start = 0.0, double end = 0.0)
        {
            Start = start;
            End = end;
        }

        public static AlphaSection FromFuzzy(FuzzyNumber fuzzy)
        {
            var alpha = new AlphaSection();
            alpha.Start = AlphaValue * fuzzy.Middle + (1 - AlphaValue) * fuzzy.Left;
            alpha.End = AlphaValue * fuzzy.Middle + (1 - AlphaValue) * fuzzy.Right;

            return alpha;
        }

        public static AlphaSection operator +(AlphaSection a1, AlphaSection a2)
        {
            return new AlphaSection(a1.Start + a2.Start, a1.End + a2.End);
        }

        public static AlphaSection operator +(AlphaSection a, FuzzyNumber f)
        {
            var alpha = FromFuzzy(f);
            return alpha + a;
        }

        public static AlphaSection operator +(FuzzyNumber f, AlphaSection a)
        {
            return a + f;
        }

        public static AlphaSection operator -(AlphaSection a1, AlphaSection a2)
        {
            return new AlphaSection(a1.Start - a2.Start, a1.End - a2.End);
        }

        public static AlphaSection operator *(AlphaSection a1, AlphaSection a2)
        {
            return new AlphaSection(a1.Start * a2.Start, a1.End * a2.End);
        }

        public static AlphaSection operator *(AlphaSection a, FuzzyNumber f)
        {
            var alpha = FromFuzzy(f);
            return a * alpha;
        }

        public static AlphaSection operator *(FuzzyNumber f, AlphaSection a)
        {
            var alpha = FromFuzzy(f);
            return a * alpha;
        }

        public static AlphaSection operator *(AlphaSection a, double d)
        {
            return new AlphaSection(a.Start * d, a.End * d);
        }

        public static AlphaSection operator ^(AlphaSection alpha, double pow)
        {
            return new AlphaSection(Math.Pow(alpha.Start, pow), Math.Pow(alpha.End, pow));
        }
    }
}
