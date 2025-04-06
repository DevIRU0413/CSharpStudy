using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Potion
    {
        public string Name { get; private set; }
        public int PotionPoint { get; private set; }

        public int Price { get; private set; }

        public Potion(string name, int potionPoint, int price)
        {
            Name = name;
            PotionPoint = potionPoint;
            Price = price;
        }

        public void Print()
        {
            Console.WriteLine($"포션 이름: {Name}");
            Console.WriteLine($"포션 포인트: {PotionPoint}");
            Console.WriteLine($"가격: {Price}");
        }
    }
}
