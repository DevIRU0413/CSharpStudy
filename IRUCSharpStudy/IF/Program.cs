using System;

namespace IF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerHp = 100;
            string inputDamage;
            int damageTaken = 0;

            // 입력
            Console.Write($"플레이어의 현재 체력은 {playerHp} 입니다.");
            Console.WriteLine("플레이어가 받을 피해를 입력해주세요.");
            Console.Write("[받을 데미지 입력]: ");
            inputDamage = Console.ReadLine();

            // 맞는지 판단
            if (int.TryParse(inputDamage, out damageTaken))
            {
                Console.WriteLine($"정상적인 데미지 값이 들어왔습니다. > 받는 데미지 값 {damageTaken}");
                Console.WriteLine($"-{damageTaken}!!!!!!!!");
            }
            else
            {
                damageTaken = 0;
                Console.WriteLine("비정상적인 데미지 값이 들어왔습니다. > 받는 데미지가 0으로 변경됩니다.");
            }

            // 피해 입는 식
            playerHp -= damageTaken; // playerHp = playerHp - damageTaken;
            Console.WriteLine($"플레이어의 현재 체력은 {playerHp} 입니다.");

            Console.WriteLine("==================================================");

            int score = 0;
            string inputScore;

            Console.WriteLine("당신의 랭크 점수를 입력해주세요.");
            Console.Write("[점수 입력]: ");
            inputScore = Console.ReadLine();

            if (int.TryParse(inputScore, out score))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("정상적인");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("비정상적인");
            }
            Console.WriteLine(" 점수 입력입니다.");
            Console.ResetColor();

            if (score <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("[미배치]");
            }
            else if (score <= 50)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[브론즈 랭크]");
            }
            else if (score <= 60)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("[실버 랭크]");
            }
            else if (score <= 70)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[골드 랭크]");
            }
            else if (score <= 80)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[플레티넘 랭크]");
            }
            else if (score <= 90)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("[다이야몬드 랭크]");
            }
            else if (score <= 100)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("[첼린저 랭크]");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR]");
            }
        }
    }
}
