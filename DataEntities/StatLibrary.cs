using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAnalyzeSys.DataEntities
{
    public static class StatLibrary     //библиотека для вычисления статистических величин. Классика. В дальнейшем можно улучшать методы и оптимизировать код
    {
        public static double Calculate(string value, double[] data_set)
        {
            switch (value)
            {
                case "maximal": return findMax(data_set);
                case "minimal": return findMin(data_set);
                case "arithmetical mean": return arithmeticalMean(data_set);
                case "geometrical mean": return geometricalMean(data_set);
            }
            return -1;
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
            foreach (double e in data) summary *= e / data.Length;
            return summary;
        }
    }
}
