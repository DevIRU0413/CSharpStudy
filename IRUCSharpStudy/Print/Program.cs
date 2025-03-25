using System;

namespace Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 문자열 줄 바꿈 출력
            Console.WriteLine("Hello World!");

            Console.WriteLine("\n");

            // 문자열 줄 바꿈 2줄 출력
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");

            Console.WriteLine("\n");

            // Error!!!
            // WriteLine("Hello World!");

            // 문자열 줄 바꿈 없이 2줄 출력
            Console.Write("Hello World!");
            Console.Write("Hello World!");

            Console.WriteLine("\n");

            // 문자열 줄 바꿈 없음과 있음 복합 출력
            Console.Write("Hello World!");
            Console.WriteLine("Hello World!");
            Console.Write("Hello World!");

            Console.WriteLine("\n");

            // 자리표시자 출력 방법
            Console.WriteLine("Hello {0}!", "World"); // 1
            Console.WriteLine("{0} {1}!", "Hello", "World"); // 2
            Console.WriteLine("{0} {0}!", "Hello", "World"); // 3
            Console.WriteLine("{1} {1}!", "Hello", "World"); // 4
            Console.WriteLine("{0} {1}!", 1, 2); // 5
            Console.WriteLine("{0} {1}", 1, 2); // 6
            Console.WriteLine("{0} {1}", "1", "2"); // 7
            Console.WriteLine("{0} {1}", 2, 2); // 8
            Console.WriteLine("{0} {1}", 10 + 1, 10 - 1); // 9
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}...", "안", "녕", "하", "세", "요", "~", "~~!!!"); // 9
            Console.WriteLine("{0}, {0}, {1}, {1}, {1}, {5}, {1}...", "안", "녕", "하", "세", "요", "~", "~~!!!");
        }
    }
}
