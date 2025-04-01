namespace Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            | 형태                  | 반환값  | 매개변수  | 설명 및 특징                                    | 예시 코드 (간단 표현)                          |
            |-----------------------|--------|-----------|-----------------------------------------------|-----------------------------------------------|
            | 기본 함수 (일반)       | ❌      | ❌      | 가장 단순한 형태                                | `void Hello() { ... }`                        |
            | 기본 함수 (입력 있음)   | ❌      | ✅     | 입력만 받고 결과 없음                            | `void Print(string s)`                        |
            | 기본 함수 (출력 있음)   | ✅      | ❌     | 입력 없이 결과만 반환                            | `int GetCount() => 5;`                        |
            | 일반 함수 (입출력 있음) | ✅      | ✅      | 가장 일반적인 형태                              | `int Add(int a, int b)`                       |
            | 재귀 함수              | ✅      | ✅      | 자기 자신을 호출하는 함수                       | `int Fact(int n) => n == 1 ? 1 : n * Fact(n-1);`|
            | 익명 함수 (delegate)   | ✅/❌  | ✅/❌   | 이름이 없는 함수, delegate로 선언               | `delegate(int x) { return x * x; }`           |
            | 람다식                 | ✅/❌  | ✅/❌   | 화살표(=>)를 이용한 간결한 표현식 함수           | `(x, y) => x + y`                             | 
             */

            Hello();
            Hello();

            MovieEndingTime("미키 17", 2, 17, 0);
            MovieEndingTime("어벤져스", 2, 23, 0);
            MovieEndingTime("나 홀로 집에", 1, 43, 0);

            Console.WriteLine("PI 값은?");
            Console.WriteLine(PI());

            int numA = 10;
            int numB = 3;
            Console.WriteLine(Add(numA, numB));
            Console.WriteLine(Minus(numA, numB));
            Console.WriteLine(Multiply(numA, numB));
            Console.WriteLine(Divide(numA, numB));

            Console.WriteLine(Pow(2, 0));
            Console.WriteLine(Pow(2, 4));
            Console.WriteLine(Pow(2, 8));
        }

        static void Hello()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("World!");
            Console.WriteLine("");
        }

        static void MovieEndingTime(string movieName, uint hour, uint minute, uint second)
        {
            Console.WriteLine("[영화 이름]: {0}", movieName);
            Console.WriteLine("[영화 상영 시간]: {0}:{1}:{2}", hour, minute, second);
        }

        static float PI()
        {
            return 3.141592f;
        }

        static int Add(int num1, int num2)
        {
            int sumResult = num1 + num2;
            return sumResult;
        }

        static int Minus(int num1, int num2)
        {
            int minusResult = num1 - num2;
            return minusResult;
        }

        static int Multiply(int num1, int num2)
        {
            int multiplyResult = num1 * num2;
            return multiplyResult;
        }

        static int Divide(int num1, int num2)
        {
            int divideResult = num1 / num2;
            return divideResult;
        }

        static int Pow(int b, int n)
        {
            if (n > 0)
                return b * Pow(b, n - 1);
            else
                return 1;
        }
    }
}
