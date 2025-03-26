using System;

namespace ReadInput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                | 메서드               | 설명                                    | 반환 타입    |
                |---------------------|-----------------------------------------|-------------|
                | `Console.Read()`    | 문자 하나를 **정수(Unicode)** 로 읽음     | `int`       |
                | `Console.ReadLine()`| **한 줄 전체 문자열** 을 입력받아 반환     | `string`    |

                | 항목             | `Console.Read()`                        | `Console.ReadLine()`                    |
                |------------------|-----------------------------------------|-----------------------------------------|
                | **입력 단위**     | 문자 한 개 (유니코드 값 하나)             | 한 줄 전체 (Enter 키까지 입력)            |
                | **반환 타입**     | `int`                                   | `string`                                |
                | **입력 종료 조건**| 문자 1개 입력 + Enter                    | Enter 키 입력 시 한 줄 반환               |
                | **사용 용도**     | 문자/키 코드 처리                        | 일반 문자열, 숫자 입력 등                 |
            */

            Console.Write("문자 하나를 입력하세요: ");
            int input = Console.Read();
            Console.WriteLine($"입력한 문자: {(char)input}, 유니코드: {input}");

            Console.Write("이름을 입력하세요: ");
            string name = Console.ReadLine();
            Console.WriteLine($"안녕하세요, {name}님!");
        }
    }
}
