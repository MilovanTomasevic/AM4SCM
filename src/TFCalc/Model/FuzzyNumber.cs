using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFCalc.Model
{
    [Serializable]
    public class FuzzyNumber
    {
        public double Left { get; set; }
        public double Middle { get; set; }
        public double Right { get; set; }

        public FuzzyNumber(double left = 0.0, double middle = 0.0, double right = 0.0)
        {
            Left = left;
            Middle = middle;
            Right = right;
        }

        public static AlphaSection operator *(FuzzyNumber f1, FuzzyNumber f2)
        {
            AlphaSection res = new AlphaSection();
            res.Start = f1.Left * f2.Left + AlphaSection.AlphaValue * (f1.Left * f2.Middle - 2.0 * f1.Left * f2.Left + f2.Left * f1.Middle) + Math.Pow(AlphaSection.AlphaValue, 2.0) * (f1.Middle - f1.Left) * (f2.Middle - f2.Left);
            res.End = f1.Right * f2.Right + AlphaSection.AlphaValue * (f1.Middle * f2.Right - 2.0 * f1.Right * f2.Right + f1.Right * f2.Middle) + Math.Pow(AlphaSection.AlphaValue, 2.0) * (f1.Middle - f1.Right) * (f2.Middle - f2.Right);
            return res;
        }

        public static FuzzyNumber operator *(FuzzyNumber fuzzy, double score)
        {
            var res = new FuzzyNumber();
            res.Left = fuzzy.Left * score;
            res.Middle = fuzzy.Middle * score;
            res.Right = fuzzy.Right * score;
            return res;
        }

        public static FuzzyNumber operator +(FuzzyNumber f1, FuzzyNumber f2)
        {
            return new FuzzyNumber(f1.Left + f2.Left, f1.Middle + f2.Middle, f1.Right + f2.Right);
        }

        public static FuzzyNumber operator ^(FuzzyNumber fuzzy, double pow)
        {
            var res = new FuzzyNumber();
            res.Left = Math.Pow(fuzzy.Left, pow);
            res.Middle = Math.Pow(fuzzy.Middle, pow);
            res.Right = Math.Pow(fuzzy.Right, pow);

            return res;
        }
    }
}
