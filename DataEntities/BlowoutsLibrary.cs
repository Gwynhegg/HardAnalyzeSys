using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAnalyzeSys.DataEntities
{
    public static class BlowoutsLibrary
    {
        public static DataStructure interquartileDistance(DataEntities.DataStructure data)
        {
            double[] sample;
            int[] indexes = new int[data.sizeOfStructure()];
            List<int> correct_indexes = new List<int>();
            List<string> data_types = data.getDataTypes();
            for (int i = 0; i < data_types.Count; i++)
                if (data_types[i] == "int" || data_types[i] == "double") correct_indexes.Add(i);

            for (int column = 0; column < correct_indexes.Count; column++)
            {
                sample = new double[data.sizeOfStructure()];
                for (int i = 0; i < sample.Length; i++) 
                { 
                    sample[i] = Double.Parse(data[i][correct_indexes[column]].ToString());
                    indexes[i] = i;
                }

                sortIndexMaintaining(sample, indexes, 0, sample.Length-1);
                double median, first_quart, last_quart;
                int first_ind, second_ind;
                if (sample.Length % 2 == 0)
                {
                    first_ind = sample.Length / 2 - 1;
                    second_ind = first_ind + 1;
                }
                else 
                { 
                    first_ind = (sample.Length - 1) / 2 - 1;
                    second_ind = first_ind + 2;
                }

                int temp = first_ind / 2;
                if (first_ind % 2 == 0) {
                    first_quart = sample[temp];
                    last_quart = sample[second_ind + temp];
                } else
                {
                    first_quart = (sample[temp] + sample[temp + 1]) / 2;
                    last_quart = (sample[second_ind + temp] + sample[second_ind + temp + 1]) / 2;
                }

                double left_interval = first_quart - 3 * (last_quart - first_quart), right_interval = first_quart + 3 * (last_quart - first_quart);
                for (int i = sample.Length-1; i >= 0; i--)
                    if (sample[i] < left_interval || sample[i] > right_interval) data.deleteRecord(i);
            }

            return data;
        }

        private static void sortIndexMaintaining(double[] sample,int[] indexes, int min, int max)
        {
            if (min >= max)
            {
                return;
            }

            int pivot = getPartition(sample, indexes, min, max);
            sortIndexMaintaining(sample, indexes, min, pivot - 1);
            sortIndexMaintaining(sample, indexes, pivot + 1, max);
        }

        private static int getPartition(double[] array, int[] indexes, int min, int max)
        {
            int pivot = min - 1;
            for (int i = min; i < max; i++)
            {
                if (array[i] < array[max])
                {
                    pivot++;
                    swap(ref array[pivot], ref array[i]);
                    swap(ref indexes[pivot], ref indexes[i]);
                }
            }

            pivot++;
            swap(ref array[pivot], ref array[max]);
            swap(ref indexes[pivot], ref indexes[max]);
            return pivot;
        }

        private static void swap(ref double x, ref double y)
        {
            double temp = x;
            x = y;
            y = temp;
        }

        private static void swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

    }
}
