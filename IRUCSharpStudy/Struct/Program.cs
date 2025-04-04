using static Struct.Program;

namespace Struct
{
    internal class Program
    {
        public struct Potion
        {
            public string Name;
            public int PotionPoint;

            public int Price;

            public void Print()
            {
                Console.WriteLine($"포션 이름: {Name}");
                Console.WriteLine($"포션 포인트: {PotionPoint}");
                Console.WriteLine($"가격: {Price}");
            }
        }

        public struct Player
        {
            public string Name;

            public int HealthPoint; // 체력
            public int HealthMaxPoint; // 최대 체력
            public int AttackPower; // 공격력
            public int DefensePoint; // 방어력

            public int HaveGold;

            // 플레이어 정보를 콘솔에서 확인할 수 있는 함수 
            public void Print()
            {
                Console.WriteLine($"플레이어 이름 {Name}");
                Console.WriteLine($"플레이어 체력 {HealthPoint} / {HealthMaxPoint}");
                Console.WriteLine($"플레이어 공격력 {AttackPower}");
                Console.WriteLine($"플레이어 방어력 {DefensePoint}");
                Console.WriteLine($"플레이어 소지금 {HaveGold}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // 각각 체력 회복 ,공격 상승, 방어력 상승
            Player player = new();

            player.Name = "DevIRU";
            player.HealthMaxPoint = 10;
            player.HealthPoint = player.HealthMaxPoint;
            player.AttackPower = 10;
            player.DefensePoint = 2;

            Potion[] potions = new Potion[3];

            potions[0].Name = "체력 회복 포션";
            potions[0].PotionPoint = 2;
            potions[0].Price = 5;

            potions[1].Name = "공격 상승 포션";
            potions[1].PotionPoint = 3;
            potions[1].Price = 15;

            potions[2].Name = "방어력 상승 포션";
            potions[2].PotionPoint = 1;
            potions[2].Price = 10;


            player.Print();

            foreach (Potion potion in potions)
                potion.Print();
        }
    }
}
