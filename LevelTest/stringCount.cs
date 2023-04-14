using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTest
{
    internal class stringCount
    {
        static public void stringCounts()
        {
            Console.WriteLine("문자열을 입력해 주세요.");
            string s = Console.ReadLine();
            string[] str = s.Split(' ');
            Console.WriteLine(str.Length);
        }

    }
}
