using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using TFCalc.Model;

namespace TFCalc
{
    public static class Tools
    {
        private static string AppRoot = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\TFCalc";
        public static string SettingsPath = Path.Combine (AppRoot, "Settings.tfcd");
        public static string RPath = Path.Combine(AppRoot, "RValues.tfcd");
        public static string WeightPath = Path.Combine(AppRoot, "Weights.tfcd");
        public static string ServicesPath = Path.Combine(AppRoot, "Services.tfcd");

        public static void SaveSettings(Settings settings)
        {
            SaveObject(settings, SettingsPath);
        }

        public static Settings LoadSettings()
        {
            return LoadObject<Settings>(SettingsPath);
        }

        public static void SaveObject<T>(T data, string path)
        {
            //XmlSerializer writter = new XmlSerializer(typeof(T));
            IFormatter formatter = new BinaryFormatter();
            var dir = Directory.GetParent(path);
            if (!dir.Exists)
                dir.Create();
            FileStream file = File.Create(path);
            //writter.Serialize(file, data);
            formatter.Serialize(file, data);
            file.Close();
        }

        public static void SaveObject<T>(T data, FileStream stream)
        {
            //XmlSerializer writter = new XmlSerializer(typeof(T));
            //writter.Serialize(stream, data);

            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);

            //client should taje care of closing the stream
            //stream.Close();
        }

        public static T LoadObject<T>(string path)
        {
            //XmlSerializer reader = new XmlSerializer(typeof(T));
            IFormatter formatter = new BinaryFormatter();
            T data = default(T);
            try
            {
                //var file = new StreamReader(path);
                var stream = new FileStream(path, FileMode.Open);
                data = (T)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return data;
        }

        public static T LoadObject<T>(Stream stream)
        {
            //XmlSerializer reader = new XmlSerializer(typeof(T));
            IFormatter formatter = new BinaryFormatter();
            T data = default(T);
            try
            {
                //var file = new StreamReader(stream);
                data = (T)formatter.Deserialize(stream);
                //client should take care of stream closing
                //file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return data;
        }

        public static void AddAll<T>(IList<T> source, IList<T> dest)
        {
            foreach (var item in source)
            {
                dest.Add(item);
            }
        }

        public static string FindStringValue(List<string> list, double value, int precision = 2)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var d = 0.0;
                if (double.TryParse(list[i], out d))
                {
                    if (Math.Round(d, precision) == Math.Round(value, precision))
                        return list[i];
                }
            }
            return list[0];
        }

        public static void FuzzySumAdd(ref FuzzyNumber sum, FuzzyNumber weight, FuzzyNumber score, double r)
        {
            sum.Left += weight.Left * Math.Pow(score.Left, r);
            sum.Middle += weight.Middle * Math.Pow(score.Middle, r);
            sum.Right += weight.Right * Math.Pow(score.Right, r);
        }

        public static void FuzzyPow(ref FuzzyNumber res, FuzzyNumber powBase, double pow)
        {
            res.Left = Math.Pow(powBase.Left, pow);
            res.Middle = Math.Pow(powBase.Middle, pow);
            res.Right = Math.Pow(powBase.Right, pow);
        }

        public static void FillRTable(BindingList<RValues> rTable)
        {
            rTable.Add(new RValues { Name = "Replaceability - Strongest - D = +oo", Value = double.PositiveInfinity , DisplayName="D"});
            rTable.Add(new RValues { Name = "Replaceability - Very Strong - D++", Value = 20.63, DisplayName="D++" });
            rTable.Add(new RValues { Name = "Replaceability - Strong - D+", Value=9.521, DisplayName="D+" });
            rTable.Add(new RValues { Name = "Replaceability - Medium Strong - D+-", Value=5.802, DisplayName="D+-" });
            rTable.Add(new RValues { Name = "Replaceability - Medium - DA", Value=3.929, DisplayName="DA" });
            rTable.Add(new RValues { Name = "Replaceability - Medium Weak - D-+", Value= 2.792, DisplayName="D-+" });
            rTable.Add(new RValues { Name = "Replaceability - Weak - D-", Value=2.018, DisplayName="D-" });
            rTable.Add(new RValues { Name = "Replaceability - Very Weak - D--", Value=1.499, DisplayName="D--" });
            rTable.Add(new RValues { Name = "Neutrality - A", Value= 1.0, DisplayName="A" });
            rTable.Add(new RValues { Name = "Simultaneity - Very Weak - C--", Value=0.619, DisplayName="C--" });
            rTable.Add(new RValues { Name = "Simultaneity - Weak - C-", Value=0.261, DisplayName="C-" });
            rTable.Add(new RValues { Name = "Simultaneity - Medium Weak - C-+", Value=-0.148, DisplayName="C-+" });
            rTable.Add(new RValues { Name = "Simultaneity - Medium - CA", Value=-0.72, DisplayName="CA" });
            rTable.Add(new RValues { Name = "Simultaneity - Medium Strong - C+-", Value=-1.655, DisplayName="C+-" });
            rTable.Add(new RValues { Name = "Simultaneity - Strong - C+", Value = -3.510, DisplayName="C+" });
            rTable.Add(new RValues { Name = "Simultaneity - Very Strong - C++", Value=-9.06, DisplayName="C++" });
            rTable.Add(new RValues { Name = "Simultaneity - Strongest - C = -oo", Value = double.NegativeInfinity, DisplayName="C" });
        }

        public static BindingList<RValues> GetNewRTable()
        {
            var list = new BindingList<RValues>();
            FillRTable(list);

            return list;
        }
    }
}
