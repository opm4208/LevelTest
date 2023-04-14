using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTest
{
    internal class SumOfDigitscs
    {
        static int SumOfDigitse(int num)
        {
            string str = string.Format("{0}", num);
            char[] strarray = str.ToCharArray();
            int[] nums = new int[strarray.Length];
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(strarray[i].ToString());
                Console.WriteLine(strarray[i]);
                sum += nums[i];
            }
            return sum;
        }

    }
}
