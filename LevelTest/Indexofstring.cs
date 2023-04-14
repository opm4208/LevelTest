using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTest
{
    internal class Indexofstring
    {
        static public void Indexofstrings()
        {
            Console.WriteLine("문자열을 입력해 주세요.");
            string str = Console.ReadLine();
            Console.WriteLine("문자열에서 찾을 문자열을 입력해 주세요.");
            string s = Console.ReadLine();
            Console.WriteLine(str.IndexOf(s));
        }

    }
}
