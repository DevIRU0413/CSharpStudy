using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Shop
    {
        private Potion[] _potions; // 포션 종류

        public Shop()
        {
            // 각각 체력 회복 ,공격 상승, 방어력 상승
            _potions = new Potion[3];

            _potions[0] = new Potion("체력 회복 포션", 2, 5);
            _potions[1] = new Potion("공격 상승 포션", 3, 15);
            _potions[2] = new Potion("방어력 상승 포션", 1, 10);
        }

        public Potion Shoping(Player player)
        {
            Console.WriteLine("말도 안되게 큰 가방을 매고 있는 상인이 보인다");
            Console.WriteLine("[상인]: 안녕하신가? 모험가여?");
            Console.WriteLine("[상인]: 뭐 살것이 있는가? 없어도 한번 보고가지");
            Console.WriteLine("쿵!.. (엄청 큰 가방을 내려놓는 소리)");

            Console.WriteLine();
            Console.WriteLine("==========물품 리스트==========");
            // 가지고 있는 물품 출력
            Potion potion;
            for (int i = 0; i < _potions.Length; i++)
            {
                potion = _potions[i];
                Console.WriteLine($"{i + 1}. [{potion.Name}] [G {potion.Price}]");
            }

            Console.WriteLine();
            Console.WriteLine("==========플레이어 정보==========");
            // 플레이어가 가지고 있는 소지금 현황
            // 여기서는 기존에 만들어 놓은 함수 사용
            player.Print();


            // 잘못 입력했는지 판별
            Console.Write("\n[구매 할 물품 번호 입력]: ");
            int tryBayIdx;
            bool isUsable= int.TryParse(Console.ReadLine(), out tryBayIdx);
            if (!isUsable || 1 > tryBayIdx || _potions.Length < tryBayIdx)
            {
                Console.WriteLine("잘못된 선택을 하였습니다!!");
                return null;
            }

            // 가지고 있는 물품 판매가능 여부 판단
            tryBayIdx -= 1;
            Potion bayPotion = _potions[tryBayIdx];
            if (bayPotion.Equals(default))
            {
                Console.WriteLine("선택한 포션의 재고가 없습니다!!");
                return null;
            }

            // 플레이어가 사고싶은 것을 구매 가능 여부 판단
            if (player.HaveGold < bayPotion.Price)
            {
                Console.WriteLine($"양심이 없는가? G {bayPotion.Price - player.HaveGold}가 부족하지 않나!");
                Console.WriteLine("돈이 있을 때, 다시보지!");
                return null;
            }

            // 구매
            player.HaveGold -= bayPotion.Price;
            Console.WriteLine($"오? 모함가, [{bayPotion.Name}] 구매는 좋은 선택이야");

            return bayPotion;
        }

        public void PrintPotions()
        {
            if (_potions == null) return;

            foreach (Potion potion in _potions)
                potion.Print();
        }
    }
}
