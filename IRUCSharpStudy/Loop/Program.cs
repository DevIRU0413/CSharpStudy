using System;

namespace Loop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Loop문 반복이 가능한 구문

            // 반복하는 구문 반복문에는 어떠한 것들이 있을?
            // 반복문에는 `while`, `do~while`, `for`, `foreach`이 있습니다.

            // 하지만 각각 사용방법 조금씩 다릅니다.

            // while 부터 보겠습니다. 
            /*
            while(참 or 거짓)
            {
                반복 할 내용
            }
            */

            // 위와 같은 식으로 사용 되며, while 뒤에 소괄호에는 조건을 넣어서 참 거짓을 받아도 됩니다.

            int eatApple = 0;

            while (eatApple < 10)
            {
                eatApple++;
                Console.WriteLine($"{eatApple}번째로 사과를 먹습니다.");
            }

            Console.WriteLine("사과 {0}개까지 먹어서 배가 부르다.. 꺼어억", eatApple);
            // 이렇게 조건이 맞을 때 반복을 실행 시키고, 조건이 맞지 않다면 조건을 멈춥니다.


            // do while은 조건이 없이 먼저 실행하고, 그 다음에 조건을 확인합니다. 틀렸다면 실행하지 않고, 맞았다면 반복시킵니다.
            /*
            do
            {
                반복 할 내용
            } while(참 or 거짓);
            */
            do
            {
                eatApple++;
                Console.WriteLine($"일단은 {eatApple}번째로 사과를 먹습니다.");
            } while (eatApple < 20);

            Console.WriteLine("사과 {0}개까지 먹어서 배가 터지겠뜨아ㅏ....", eatApple);

            // for
            string[] students = { "짱구", "철수", "맹구", "유리", "훈이" };
            /*
            for (초기화; 조건; 증감 or 처리)
            {
                반복 할 내용
            }
            */
            // for 순서 : 초반 한번만 (1 > 2 > 3 > 4), 이후 지속적으로 (2 > 3 > 4)
            // 1. int i 라는 변수를 선언과 즉시 초기화 진행
            // 2. i < students.Length 해당 조건이 맞는지 확인
            // 3. 조건이 맞았으니, 반복 할 내용 실행
            // 4. i++로 증감 or 처리 실행
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"{i + 1}번 학생 이름: {students[i]}");
            }

            // 이렇게 변경 할 수도 있다.
            // 처리하는 곳에 삼항 연산자를 사용하여 처리 할 수 있다.
            int count = 0;
            for (string name = students[count]; count < students.Length; name = (count < students.Length) ? students[count] : null)
            {
                Console.WriteLine($"{count + 1}번 학생 이름: {name}");
                count++;
            }

            // 그럼. 바로 위에 보다 배열의 요소들을 더욱 쉽게, 가지고 올 수 있는 방법은 없을까?
            // 그것이 바로 foreach문이다.
            count = 0;
            foreach (string name in students)
            {
                Console.WriteLine($"{count + 1}번 학생 이름: {name}");
                count++;
            }
            // foreach 문의 장점은 위와 같이 코드가 간략화되고,
            // 배열이나 리스트의 있는 요소들을 순서대로 가지고 온다는 것이다.
            // 단점은 요소의 직접 접근 불가능하여, 반환 받은 값 타입 요소를 수정해도 반영되지 않는다는 단점이 있다.
            // 그리고 요소는 readonly, 즉 읽기 전용이여서 값을 바꾸려고 하면 에러가 납니다.
        }
    }
}
