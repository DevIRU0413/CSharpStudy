namespace Class
{
    public struct VectorInt2
    {
        public int x;
        public int y;

        public VectorInt2(int x, int y)
        {
            this.x = x; 
            this.y = y;
        }

        public static VectorInt2 Zero = new VectorInt2(0, 0);
    }

    public class Car
    {
        public string Model;
        public void Drive()
        {
            Console.WriteLine($"{Model}이(가) 달립니다.");
        }
    }

    abstract class Unit
    {
        public readonly string Name;
        public int HP;

        public VectorInt2 Position { get; private set; }

        public Unit(VectorInt2 position)
        {
            Name = "None"; // 기본 이름
            HP = 100; // 기본 체력
            Position = VectorInt2.Zero;
        }

        public Unit(string name, VectorInt2 position)
        {
            Name = name;
            HP = 100; // 기본 체력
            Position = position;
        }

        public Unit(string name, int hp, VectorInt2 position)
        {
            Name = name;
            HP = hp;
            Position = position;
        }
    }

    sealed class Player : Unit // sealed로 더 이상 상속되지 않게 설정
    {
        public Player(VectorInt2 position) : base(position)
        {
            InitPrint(); // 출력
        }
        public Player(string name, VectorInt2 position) : base(name, position)
        {
            InitPrint();
        }
        public Player(string name, int hp, VectorInt2 position) : base(name, hp, position)
        {
            InitPrint();
        }

        private void InitPrint()
        {
            Console.WriteLine("플레이어 초기화됨!");
            Console.WriteLine($"플레이어 이름: {Name}");
            Console.WriteLine($"플레이어 이름: {HP}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // # 클래스
            // - 클래스는 객체를 생성하기 위한 설계도 또는 틀
            // - 객체는 클래스로부터 생성된 인스턴스
            // - 클래스에는 필드, 메서드, 생성자, 이벤트 등을 정의 가능

            Car myCar = new Car(); // new 키워드로 생성자 사용
            myCar.Model = "소나타"; // 내부의 외부 공개 가능한 값에 접근 및 값 할당
            myCar.Drive(); // 내부의 외부 공개 가능한 함수 기능 사용
        }
    }
}
