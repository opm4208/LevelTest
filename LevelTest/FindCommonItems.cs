using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTest
{
    internal class FindCommonItems
    {
        static int[] FindCommonItemse(int[] arr1, int[] arr2, int[] arr3)
        {
            bool[] checkct = { false, false };
            List<int> list = new List<int>();
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        checkct[0] = true;
                        break;
                    }
                    else if (arr1[i] < arr2[j])
                    {
                        break;
                    }
                }
                for (int k = 0; k < arr3.Length; k++)
                {
                    if (arr1[i] == arr3[k])
                    {
                        checkct[1] = true;
                        break;
                    }
                    else if (arr1[i] < arr3[k])
                    {
                        break;
                    }
                }
                if (checkct[0] && checkct[1])
                {
                    list.Add(arr1[i]);
                }
                checkct[0] = false;
                checkct[1] = false;
            }
            list = list.Distinct().ToList();
            int[] ints = list.ToArray();
            return ints;
        }

    }
}
