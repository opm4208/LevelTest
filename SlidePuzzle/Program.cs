namespace SlidePuzzle
{
    internal class Program
    {
        enum Direction { Up, Down, Left, Right, None }
        struct Point // 게임에 필요한 좌표값들을 구조체로 표현
        {
            public int x;
            public int y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        static int[,] PuzzleSetting()
        {
            Random rand = new Random();
            List<int> list = new List<int>();
            int num = rand.Next(0, 25);
            list.Add(num);
            while (true)
            {
                bool check = true;
                num = rand.Next(0, 25);
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == num)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    list.Add(num);
                }
                if (list.Count == 25)
                {
                    break;
                }
            }

            int count = 0;
            int[,] puzzle = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    puzzle[i, j] = list[count++];
                }
            }
            return puzzle;
        }
        static Direction GameInput()
        {
            Direction direction; // 위에서 정의한 방향 enum 변수를 생성.
            ConsoleKeyInfo info = Console.ReadKey(); // 화살표키 입력을 받아서 변수에 저장.
            switch (info.Key) // 변수에 저장한 값을 switch 문에 넣어서 실행
            {
                case ConsoleKey.UpArrow:// 키값이 위키였을시 enum변수에 Up 저장.
                    direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:// 키값이 아래키였을시 enum변수에 Down 저장.
                    direction = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:// 키값이 위키였을시 enum변수에 Left 저장.
                    direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:// 키값이 위키였을시 enum변수에 Right 저장.
                    direction = Direction.Right;
                    break;
                default:// 키값이 위키였을시 enum변수에 None 저장.
                    direction = Direction.None;
                    break;
            }
            return direction; // 변수에 저장한 방향값을 반환
        }
        static (int[,],Point) GameUpdate(Direction input, Point zero, int[,] puzzle)
        {
            Point prevzero = zero;
            switch (input)// 매개변수로 받은 방향 값을 키로 switch문 실행
            {
                case Direction.Up: // 매개변수가 위키 였을시 player의 위치를 y-1로 저장
                    zero.x--;
                    break;
                case Direction.Down: // 매개변수가 아래키 였을시 player의 위치를 y+1로 저장
                    zero.x++;
                    break;
                case Direction.Left: // 매개변수가 왼쪽키 였을시 player의 위치를 x-1로 저장
                    zero.y--;
                    break;
                case Direction.Right: // 매개변수가 왼쪽키 였을시 player의 위치를 x+1로 저장
                    zero.y++;
                    break;
                default: // 매개변수가 다른값일시 그냥 탈출
                    break;
            }
            if (zero.x < 0 || zero.x > 4 || zero.y < 0 || zero.y > 4)
            {
                zero = prevzero;
            }
            else
            {
                puzzle[prevzero.x, prevzero.y] = puzzle[zero.x, zero.y];
                puzzle[zero.x, zero.y] = 0;
            }
            return (puzzle,zero);
        }

        static void GameRender(Point zero, int[,] puzzle)
        {
            Console.Clear(); // 일단 콘솔을 초기화
            for (int y = 0; y < puzzle.GetLength(0); y++) // GetLength를 사용하여 배열의 길이만큼 2중 배열을 실행
            {
                for (int x = 0; x < puzzle.GetLength(1); x++)
                {
                    if (puzzle[y, x] < 10)
                    {
                        Console.Write(puzzle[y, x] + "     ");
                    }
                    else
                    {
                        Console.Write(puzzle[y, x] + "    ");
                    }
                }
                Console.WriteLine(); // 만약 맵에 저장된 x축이 다 그려졌을시 줄넘김.
            }
        }


        static void Main(string[] args)
        {
            int[,] puzzle = PuzzleSetting(); // 자동으로 puzzle 생성
            Point zero = new Point(0, 0);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (puzzle[i, j] == 0)
                    {
                        zero = new Point(i, j); // 0의 위치 좌표화.
                    }
                }
            }
            while (true)
            {
                Direction input = GameInput(); // 게임 입력

                (puzzle,zero) = GameUpdate(input, zero, puzzle);

                GameRender(zero, puzzle);
            }
        }
    }
}