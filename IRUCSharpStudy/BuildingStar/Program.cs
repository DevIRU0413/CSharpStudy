namespace BuildingStar
{
    internal class Program
    {
        static char star = '*';
        static char blank = ' ';

        static void Main(string[] args)
        {
            int num = 7;
            Console.WriteLine("\nBuilding Star Normal Patten Func");
            BuildingStarPatten1(num);
            BuildingStarPatten2(num);
            BuildingStarPatten3(num);
            BuildingStarPatten4(num);

            Console.WriteLine("\nBuilding Star Simple Patten Func");
            BuildingStarSimplePatten1(num);
            BuildingStarSimplePatten2(num);
            BuildingStarSimplePatten3(num);
            BuildingStarSimplePatten4(num);

            Console.WriteLine("\nBuilding Star Diamond Patten Func");
            BuildingStarDiamondPatten1(num);
            BuildingStarDiamondPatten2(num);
            BuildingStarDiamondPatten3(num);
        }


        static void BuildingStarPatten1(int num)
        {
            Console.WriteLine("==========1");
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < i + 1; j++)
                    Console.Write(star);

                Console.WriteLine();
            }
        }
        static void BuildingStarPatten2(int num)
        {
            Console.WriteLine("==========2");
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num - (i + 1); j++)
                    Console.Write(blank);

                for (int j = 0; j < i + 1; j++)
                    Console.Write(star);

                Console.WriteLine();
            }
        }
        static void BuildingStarPatten3(int num)
        {
            Console.WriteLine("==========3");
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num - i; j++)
                    Console.Write(star);

                Console.WriteLine();
            }
        }
        static void BuildingStarPatten4(int num)
        {
            Console.WriteLine("==========4");
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < i + 1; j++)
                    Console.Write(blank);

                for (int j = 0; j < num - i; j++)
                    Console.Write(star);

                Console.WriteLine();
            }
        }


        static void BuildingStarSimplePatten1(int num)
        {
            Console.WriteLine("==========1");
            for (int i = 0; i < num; i++)
                Console.WriteLine(new string(star, i + 1));
        }
        static void BuildingStarSimplePatten2(int num)
        {
            Console.WriteLine("==========2");
            for (int i = 1; i <= num; i++)
                Console.WriteLine(new string(blank, num - i) + new string(star, i));
        }
        static void BuildingStarSimplePatten3(int num)
        {
            Console.WriteLine("==========3");
            for (int i = 0; i < num; i++)
                Console.WriteLine(new string(star, num - i));
        }
        static void BuildingStarSimplePatten4(int num)
        {
            Console.WriteLine("==========4");
            for (int i = 0; i < num; i++)
                Console.WriteLine(new string(blank, i) + new string(star, num - i));
        }


        static void BuildingStarDiamondPatten1(int num)
        {
            if (num <= 1 || num % 2 == 0) return;

            int i = 0;
            int topRow = (num / 2) + 1;
            int botRow = (num / 2);

            Console.WriteLine("for문 6개");
            // 위쪽
            for (i = 0; i < topRow; i++)
            {
                for (int j = 0; j < topRow - (i + 1); j++)
                    Console.Write(blank);

                for (int j = 0; j < (i * 2) + 1; j++)
                    Console.Write(star);

                Console.WriteLine();
            }

            // 아래쪽
            for (i = 0; i < botRow; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write(blank);
                }

                for (int j = 0; j < (botRow - i) * 2 - 1; j++)
                {
                    Console.Write(star);
                }
                Console.WriteLine();
            }
        }
        static void BuildingStarDiamondPatten2(int num)
        {
            if (num <= 1 || num % 2 == 0) return;

            int bCount = 0;
            int sCount = 0;

            int half = num / 2 + 1;

            Console.WriteLine("for문 3개");
            for (int i = 0; i < num; i++)
            {
                if (half <= i)
                {
                    bCount = i - num / 2; // -2 -1 0 1 2
                    sCount = (num - i) * 2 - 1; // 9 7 5 2 1
                }
                else
                {
                    bCount = num / 2 - i; // 2 1 0 -1 2
                    sCount = i * 2 + 1; // 1 3 5 7 9
                }

                for (int j = 0; j < bCount; j++)
                    Console.Write(blank);

                for (int j = 0; j < sCount; j++)
                    Console.Write(star);

                Console.WriteLine();
            }
        }
        static void BuildingStarDiamondPatten3(int num)
        {
            if (num <= 1 || num % 2 == 0) return;

            Console.WriteLine("for문 1개");
            int half = num / 2;

            for (int i = 0; i < num; i++)
            {
                // 중간을 기준으로 대칭적인 빈칸 개수
                int bCount = Math.Abs(half - i); // 3, 2, 1, 0, 1, 2, 3  
                // 전체 개수에서 빈칸을 제외한 별 개수
                int sCount = num - 2 * bCount; // 1, 3, 5, 7, 5, 3, 1

                Console.WriteLine(new string(blank, bCount) + new string(star, sCount));
            }
        }
    }
}
