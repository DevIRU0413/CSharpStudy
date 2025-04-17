namespace Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // int는 값 타입
            int a = 5;

            // object는 참조 타입이다.
            // 아래와 같은 식으로 코드를 작성 시에는
            // a 값을 복사하여 힙에 저장을 진행
            // 값 타입 a의 값이 힙에 새 object로 복사되고
            // b 변수는 그 힙 객체의 참조를 스택에 저장한다.
            // 위 처럼 a의 데이터를 복사해서 힙 메모리에 할당하는 것을 박싱이라고 한다.
            // 암시적으로 발생한다.
            object b = a;

            // 아래와 같이 작성 시
            // 힙 메모리에 저장 되어 있던 데이터가 스택에 할당 공간을 만들고
            // 값정보를 복사하여 c 변수의 메모리 공간에 저장하는 식으로 이루어진다.
            // 명시적으로 이루어진다.
            int c = (int)b;
            c++;
            // 하지만 int 타입의 값을 object로 박싱한 후,
            // float로 언박싱하려 하면?

            // 코드 상에서는 문제 없이 진행된다.
            // 문제는 실행 시켰을 때 발생한다.
            // System.InvalidCastException: 'Unable to cast object of type 'System.Int32' to type 'System.Single'.'
            // 이런 식으로 오류가 발생한다.
            // 오류는 정수형을 실수형으로 직접 캐스팅하려고 할 때 발생한다. 
            // 보통 암시적 변환은 잘되지만, 명시적 캐스팅으로 진행할 때 잘못되었거나, 박싱된 값을 언박싱할 떄 타입이 다르면 문제가 발생한다.
            // float d = (float)b;

            // object 형식이란 C#의 존재하는 모든 클래스의 기본이 되는 자료형이다.
            // object 형식을 사용하면 데이터의 형식에 관계없이 object 형식의 자료형에 담을 수 있습니다.
            // 하지만 object는 참조 타입이므로, 값 타입을 저장하면 힙에 실제 데이터를 두고,
            // 변수는 그 참조(주소)를 가지게 된다.

            // 때문에 데이터를 다시 활용하기 위해서는 값 형식으로 변화하는 과정이 필요하다.

            // 박싱과 언박싱이 그러한 방법중 하나인데
            // object 형식과 같은 참조 형식에서 값 형식으로 변환하는 과정정을 언박싱, 반대의 과정을 박싱으라고 한다.
            // 박싱과 언박싱 과정을 거치게 되면, 곧 성능하락으로 이어지기 떄문에 최적화를 위해서는 피하는 것이 좋다.
            // 하지만 사용해야할때는 사용해야하므로 적절한 사용이 필요한 방법이다.

            // 제네릭
            // - 다양한 데이터 형식을 다룰 수 있는 방식에는 제네릭이 있다.
            // - 제네릭은 대상에 맞는 정확한 데이터 형식으로 적용해주는 역할을 한다.

            // 제네릭과 박싱/언박싱
            // - object는 형변환을 통해서 박싱과 언박싱을 진행한다.
            // 하지만 이러한 사용한 성능 저하 및 변환 과정에서 변환이 적절한지 판단 없이 진행 되므로 에러가 발생할 수 있기 때문에 사용을 지양해야한다.
            // 그래서 제네릭은 이러한 문제점을 보완하여 박싱/언박싱 단계를 거치지안고 형식을 조정하므로 성능이 향상되고 컴파일 단계에서
            // 올바른 데이터 형식으로 적용되므로 형식의 안정성이 보장된다.

            // 이와 같이 두 값을 바꿔주는 함수가 있다고 했을 때
            int aa = 10;
            int bb = 20;
            
            float cc = 30;
            float dd = 40;

            byte ee = 50;
            byte ff = 60;

            Swap(ref aa, ref bb);
            Swap(ref cc, ref dd);
            Swap(ref ee, ref ff);

            // 위와 같은 기능을 가고 있지만, 값이 다른 것을 바꿔주려고했을 때, 해당에 맞는 자료형 매개변수를 가진 함수가 있어야된다.
            // 그럴 때, 제네릭 함수를 만드러 처리한다면 코드 적으로나 성능적으로 도움이 될것이다.
            Swap<int>(ref aa, ref bb);
            Swap<float>(ref cc, ref dd);
            Swap<byte>(ref ee, ref ff);

            Console.WriteLine("실행 완료");
        }

        // 같은 기능의 일반 오버로드 함수들
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public static void Swap(ref float a, ref float b)
        {
            float temp = a;
            a = b;
            b = temp;
        }
        public static void Swap(ref byte a, ref byte b)
        {
            byte temp = a;
            a = b;
            b = temp;
        }

        // 제네릭 함수!
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        // 클래스만 매개변수로 받고 싶을 때
        public void Log<T>(T data) where T : class
        {
            Console.WriteLine(data?.ToString());
        }

        // 구조체만 매개변수로 받으려고 할 때
        public T Add<T>(T a, T b) where T : struct
        {
            return default(T); // 예시용
        }

        // 특정 인터페이스 정의한 클래스 또는 구조체를 받으려고할 때
        public T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
}
