namespace TextRPG
{
    internal class Game
    {
        // 구조체로 플레이어와 아이템 만들기
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


        private bool _gameOver = false;
        private ConsoleKey _inputKey;

        private Player _player; // 플레이어 정보
        private Potion[] _potions; // 포션 종류

        public void Play()
        {
            Init();
            Start();
            while (!_gameOver)
            {
                Render();
                Input();
                Update();
            }
        }
        private void Init()
        {
            _player.Name = "DevIRU";
            _player.HealthMaxPoint = 10;
            _player.HealthPoint = _player.HealthMaxPoint;
            _player.AttackPower = 10;
            _player.DefensePoint = 2;
            _player.HaveGold = 33;


            // 각각 체력 회복 ,공격 상승, 방어력 상승
            _potions = new Potion[3];

            _potions[0].Name = "체력 회복 포션";
            _potions[0].PotionPoint = 2;
            _potions[0].Price = 5;

            _potions[1].Name = "공격 상승 포션";
            _potions[1].PotionPoint = 3;
            _potions[1].Price = 15;

            _potions[2].Name = "방어력 상승 포션";
            _potions[2].PotionPoint = 1;
            _potions[2].Price = 10;
        }
        private void Start()
        {
            _player.Print();
            PrintPotions();
        }
        private void Render()
        {
            Console.Clear();
            Shop(ref _player);
        }
        private void Input()
        {
            _inputKey = ConsoleKey.None;
            _inputKey = Console.ReadKey(true).Key;
        }
        private void Update()
        {

        }

        private void PrintPotions()
        {
            if (_potions == null) return;

            foreach (Potion potion in _potions)
                potion.Print();
        }

        private void Shop(ref Player player)
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
                return;
            }

            // 가지고 있는 물품 판매가능 여부 판단
            tryBayIdx -= 1;
            Potion bayPotion = _potions[tryBayIdx];
            if (bayPotion.Equals(default))
            {
                Console.WriteLine("선택한 포션의 재고가 없습니다!!");
                return;
            }

            // 플레이어가 사고싶은 것을 구매 가능 여부 판단
            if (_player.HaveGold < bayPotion.Price)
            {
                Console.WriteLine($"양심이 없는가? G {bayPotion.Price - _player.HaveGold}가 부족하지 않나!");
                Console.WriteLine("돈이 있을 때, 다시보지!");
                return;
            }

            // 구매
            _player.HaveGold -= bayPotion.Price;
            Console.WriteLine($"오? 모함가, [{bayPotion.Name}] 구매는 좋은 선택이야");
        }
    }
}
