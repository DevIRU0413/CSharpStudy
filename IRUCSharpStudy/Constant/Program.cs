namespace Constant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 상수
            // 상수는 영어로는 Constant
            // 기본 뜻은 수식에서 변하지 않는 값을 뜻한다.
            // C#에서 상수는 값이 변경되지 않는 데이터를 표현하기 위해 사용된다.
            // 상수는 컴파일 타임에 값이 고정된다.
            // 이후 프로그램 실행 중 변경할 수 없습니다.



            // const 컴파일 상수
            // 1. 컴파일 시간에 값이 결정됩니다.
            // 2. 선언 시 반드시 초기화해야 하며, 변경 불가합니다.
            // 3. 기본적으로 static 처럼 동작함(인스턴스 없이 접근 가능)
            const double PI = 3.141592;
            const int MaxValue = 100;
            // MaxValue = 300; // Error! 
            Console.WriteLine(PI);
            Console.WriteLine(MaxValue);
            Console.WriteLine(Config.MaxValue);

            // 주의 할점
            // const는 상수를 컴파일 타임에 삽입하므로, 다른 어셈블리에서 변경 시 참조 프로젝트는 다시 빌드해야 반양됩니다.




            // readonly 런타임 상수
            // 1. 런타임 시 초기화 가능한 상수
            // 2. 생성자에서만 값을 설정할 수 있으며, 이후 변경 불가 (당연하겠지만 선언 시, 초기화 가능)
            // 3. 주로 클래스 필드로 사용됨.
            // 주의: readonly는 객체마다 다른 값을 가질수 있다는 점에서 const와 다르다.

            Config config = new Config(10); // 내부 WriteLine 5 출력
            Console.WriteLine(config.MaxSize); // 외부에서 생성자로 생성후 호출, 출력시 10
            // config.MaxSize = 100; // Error 읽기 전용 필드에는 할당할 수 없습니다.

            
            // static readonly
            // 1. 클래스 단위로 공통되는 읽기 전용 필드를 정의
            // 2. 한 번만 초기화되고, 이후변경불가
            // 3. 주로 공용 설정값, 상수 목록 등을 정의할 때 사용
            Console.WriteLine(Config.MinSize);
            Console.WriteLine((EquipmentType)10);
        }
    }

    public enum EquipmentType
    {
        Weapon = 10,     // 무기 10
        Armor,      // 방어구 11
        Accessory = 10   // 장신구 1000
    }

    class Config
    {
        // readonly 런타임 상수
        // 1. 런타임 시 초기화 가능한 상수
        // 2. 생성자에서만 값을 설정할 수 있으며, 이후 변경 불가 (당연하겠지만 선언 시, 초기화 가능)
        // 3. 주로 클래스 필드로 사용됨.
        // 주의: readonly는 객체마다 다른 값을 가질수 있다는 점에서 const와 다르다.

        public const double MaxValue = 100;
        public static readonly int MinSize = 5;
        public readonly int MaxSize = 5;
        public Config(int size)
        {
            Console.WriteLine(MaxSize);
            MaxSize = size;
        }
    }
}
