using System;

namespace ValueTypeVariable
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int integerNum = 10;

            Console.WriteLine("integerNum은 {0}입니다.", integerNum);
            // 같은 기능
            // Console.WriteLine("integerNum은 {0}입니다.", 10); 
            Console.WriteLine("\n");

            Console.WriteLine("{0} x {0} = {1}", integerNum, integerNum * integerNum);
            // 같은 기능
            // Console.WriteLine("{0} x {0} = {1}", 10, 10 * 10);
            Console.WriteLine("\n");

            // Multiplication table(구구단, 더 정확히는 곱셈표)
            int danNum = 2;
            Console.WriteLine("{0} x 1 = {1}", danNum, danNum * 1); // 1
            Console.WriteLine("{0} x 2 = {1}", danNum, danNum * 2); // 2
            Console.WriteLine("{0} x 3 = {1}", danNum, danNum * 3); // 3
            Console.WriteLine("{0} x 4 = {1}", danNum, danNum * 4); // 4
            Console.WriteLine("{0} x 5 = {1}", danNum, danNum * 5); // 5
            Console.WriteLine("{0} x 6 = {1}", danNum, danNum * 6); // 6
            Console.WriteLine("{0} x 7 = {1}", danNum, danNum * 7); // 7
            Console.WriteLine("{0} x 8 = {1}", danNum, danNum * 8); // 8
            Console.WriteLine("{0} x 9 = {1}", danNum, danNum * 9); // 9
            Console.WriteLine("\n");

            // 🔹 1바이트 정수형
            byte byteNum = 255;               // 0 ~ 255
            sbyte signedByteNum = -128;       // -128 ~ 127

            // 🔹 2바이트 정수형
            short shortNum = -32768;          // -32,768 ~ 32,767
            ushort unsignedShortNum = 65535;  // 0 ~ 65,535

            // 🔹 4바이트 정수형
            int integerNum2 = -2147483648;     // -2,147,483,648 ~ 2,147,483,647
            uint unsignedIntegerNum = 4294967295; // 0 ~ 4,294,967,295

            // 🔹 8바이트 정수형
            long longNum = -9223372036854775808;// -9경 ~ 9경
            ulong unsignedLongNum = 18446744073709551615; // 0 ~ 18경

            // 🔹 실수형
            float floatNum = 3.1415927f;         // 단정도 (소수점 7자리, 접미사 f 필수)
            double doubleNum = 3.14159265358979d;// 배정도 (소수점 15~16자리)
            decimal decimalNum = 79228162514264337593543950335m; // 고정 소수점 (소수점 28~29자리, 접미사 m 필수)

            // 🔹 기타
            char character = 'A';              // 문자 (유니코드 1글자)
            bool isTrue = true;                // 논리값 true/false
            // floatNum = 12.12; // Error!!
            // 구조체, 열거형 생략...


            // 참조 타입, 여기서는 string 만!!
            Console.WriteLine("{0} {1}!", "Hello", "World"); 
            Console.WriteLine("{0} {0}!", "Hello", "World"); 
            Console.WriteLine("{1} {1}!", "Hello", "World");


            // 이와 같은 방식으로 처리한다고 하면, 반복되는 수정을 줄일 수 있따.
            string helloStr = "안녕";
            string worldStr = "세상아";

            Console.WriteLine("{0} {1}!", helloStr, worldStr); 
            Console.WriteLine("{0} {0}!", helloStr, worldStr); 
            Console.WriteLine("{1} {1}!", helloStr, worldStr); 
        }
    }
}
