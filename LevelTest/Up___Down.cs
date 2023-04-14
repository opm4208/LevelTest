using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTest
{
    internal class Up___Down
    {
        static public int Randomint()
        {
            Random rand = new Random();
            int num = rand.Next(0, 1000);
            return num;
        }
        static public void UpDownGame()
        {
            int randomnum = Randomint();
            int count = 10;
            while (count > 0)
            {
                Console.WriteLine("숫자를 입력해 주세요.");
                int number = int.Parse(Console.ReadLine());
                if (number == randomnum)
                {
                    Console.WriteLine("정답입니다.");
                    break;
                }
                else if (number < randomnum)
                {
                    Console.WriteLine("Up");
                    count--;
                }
                else if (number > randomnum)
                {
                    Console.WriteLine("Down");
                    count--;
                }
            }
            if (count == 0)
            {
                bool check = true;
                Console.WriteLine("다시 시작하겠습니까?");
                while (check)
                {
                    Console.WriteLine("다시하기 y. 그만하기 n를 입력해 주세요.");
                    string str = Console.ReadLine();
                    switch (str)
                    {
                        case "y":
                        case "Y":
                            Console.WriteLine("게임을 다시 시작하겠습니다.");
                            check = false;
                            UpDownGame();
                            break;
                        case "n":
                        case "N":
                            Console.WriteLine("게임이 종료됩니다.");
                            check = false;
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다 다시 입력해 주세요.");
                            break;
                    }
                }

            }
        }
        static void Main(string[] args)
        {
            UpDownGame();
        }

    }
}
