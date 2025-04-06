namespace TextRPG
{
    public class Player
    {
        public string Name { get; private set; }

        public int HealthPoint { get; private set; }// 체력
        public int HealthMaxPoint { get; set; } // 최대 체력
        public int AttackPower { get; set; } // 공격력
        public int DefensePoint { get; set; } // 방어력

        public int HaveGold { get; set; } // 소지금


        public Player(string name, int healthPoint, int attackPower, int defensePoint, int haveGold)
        {
            Name = name;

            HealthMaxPoint = healthPoint;
            HealthPoint = healthPoint;
            AttackPower = attackPower;
            DefensePoint = defensePoint;

            HaveGold = haveGold;
        }

        public void Print()
        {
            Console.WriteLine($"Player [{Name}]");
            Console.WriteLine($"HP [{HealthPoint} / {HealthMaxPoint}]");
            Console.WriteLine($"ATK {AttackPower}, DFS {DefensePoint}");
            Console.WriteLine($"Gold {HaveGold}");
        }
    }
}
