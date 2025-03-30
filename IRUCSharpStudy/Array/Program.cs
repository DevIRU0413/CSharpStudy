using System;

namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 프로그래밍적 배열 정의?
            // > 지정한 자료형 타입의 값들을 담는 공간을 이어서 선언된 공간의 형태

            // 기본적으로 배열은 지정한 자료형 타입의 값들을 넣을 수 있는 공간을 이어서 선언된 공간의 한 형태이다.

            // 배열의 공간의 첫번째는 0번지라고 한다.
            // 만약 크기가 5인 배열이 있다면 첫번째는 0번이고 마지막은 4번지이다. 
            // 이렇게 0, 1, 2, 3, 4로 5개의 연속된 공간이 생성된 것이다.
            int[] array = new int[5]; // 0 ~ 4 까지의 공간

            // 그럼. 그 안에 접근하려면 ?
            array[0] = 10;
            array[1] = 20;
            array[2] = 30;
            array[3] = 40;
            array[4] = 50;
            // array[5] = 50; // Compilation Error!!!!!!

            // 위와 같이 접근을 해주면 된다.
            // [] 대괄호 안에 알맞은 인덱스(번지)를 넣어서 접근하여 사용이 가능하다.

            int[] arr1 = new int[5];
            int[,] arr2 = new int[2, 5];
            int[,,] arr3 = new int[5, 5, 5];

            float[] arrF1 = {5.0f, 6.0f, 7.0f, 8.0f, 9.0f, 10.0f};
            float[,] arrF2 = { { 1.0f, 2.0f, 3.0f}, { 4.0f, 5.0f, 6.0f} };
            float[,,] arrF3 = 
            {
                {
                    { 1.0f, 2.0f},
                    { 3.0f, 4.0f}
                },
                {
                    { 5.0f, 6.0f},
                    { 7.0f, 8.0f}
                }
            };

            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2 };
            jaggedArray[1] = new int[] { 3, 4, 5 };
            jaggedArray[2] = new int[] { 6 };


            string[] students = { "짱구", "철수", "맹구", "유리", "훈이" };

            // 배열의 번지에 직접 접근하여 값 가지고 오기
            Console.WriteLine($"1번 학생 이름: {students[0]}");
            Console.WriteLine($"2번 학생 이름: {students[1]}");
            Console.WriteLine($"3번 학생 이름: {students[2]}");
            Console.WriteLine($"4번 학생 이름: {students[3]}");
            Console.WriteLine($"5번 학생 이름: {students[4]}");

            // 위의 단순 출력을 for과 배열을 사용하여 단순화
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"{i + 1}번 학생 이름: {students[i]}");
            }

            // foreach를 사용하여 요소들 받아 출력
            foreach (string name in students)
            {
                Console.WriteLine($"학생 이름: {name}");
            }
        }
    }
}
