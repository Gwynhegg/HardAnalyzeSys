using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAnalyzeSys.DataEntities
{
    public static class StatLibrary     //библиотека для вычисления статистических величин. Классика. В дальнейшем можно улучшать методы и оптимизировать код
    {
        public static object Calculate(string value, object[] data_set, bool is_numeric)
        {
            if (is_numeric)
            {
                double[] parsed_set = new double[data_set.Length];
                for (int i = 0; i < data_set.Length; i++) parsed_set[i] = Convert.ToDouble(data_set[i]);
                switch (value)
                {
                    case "maximal": return findMax(parsed_set);
                    case "minimal": return findMin(parsed_set);
                    case "arithmetical mean": return arithmeticalMean(parsed_set);
                    case "geometrical mean": return geometricalMean(parsed_set);
                    case "harmonic mean": return harmonicMean(parsed_set);
                    case "square mean": return squareMean(parsed_set);
                    case "mode": return findMode(data_set);
                    case "median": return findMedian(parsed_set);
                    case "math expectation": return mathExpectation(parsed_set);
                    case "standart deviation": return standartDeviation(parsed_set);
                }
                return -1;
            }
            else
            {
                string[] string_set = data_set.Cast<string>().ToArray();
                switch (value)
                {
                    case "mode": return findMode(data_set);
                }
                return -1;
            }
           
        }

        private static double standartDeviation(double[] data)      //ДОДЕЛАТЬ!
        {
            return -1;
        }
        private static double mathExpectation(double[] data)    //ДОДЕЛАТЬ!
        {
            return -1;
        }

        private static double findMedian(double[] data)
        {
            Array.Sort(data);
            if (data.Length % 2 == 0) return (data[data.Length / 2]+data[data.Length / 2 - 1]) / 2; else return data[(data.Length - 1) / 2];
        }

        private static object findMode(object[] data)
        {
            Dictionary<object, int> frequencies = new Dictionary<object, int>();
            foreach (object e in data) if (frequencies.ContainsKey(e)) frequencies[e]++; else frequencies.Add(e, 0);
            return frequencies.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        } 

        private static string findMode(string[] data)   //ДОДЕЛАТЬ!
        {
            return "";
        }

        private static double findMin(double[] data)
        {
            double ans = data[0];
            foreach (double e in data) if (e < ans) ans = e;
            return ans;
        }

        private static double findMax(double[] data)
        {
            double ans = data[0];
            foreach (double e in data) if (e > ans) ans = e;
            return ans;
        }

        private static double arithmeticalMean(double[] data)
        {
            double summary = 0;
            foreach (double e in data) summary += e/data.Length;
            return summary;
        }

        private static double geometricalMean(double[] data)
        {
            double summary = 1;
            foreach (double e in data) summary *= e;
            return Math.Pow(summary, (double)1/data.Length);
        }

        private static double harmonicMean(double[] data)
        {
            double summary = 0;
            foreach (double e in data) summary += 1 / e;
            return data.Length / summary;
        }

        private static double squareMean(double[] data)
        {
            double summary = 0;
            foreach (double e in data) summary += Math.Pow(e, 2);
            summary /= data.Length;
            return Math.Sqrt(summary);
        }
    }
}
