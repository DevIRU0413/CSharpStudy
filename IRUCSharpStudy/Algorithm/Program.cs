namespace Algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortAlgorithm sort = new SortAlgorithm();

            // bubble sort test case
            /*int[] testA = new int[] { 5, 3, 8, 4, 2 };
            int[] testB = new int[] { 9, 7, 5, 3, 1 };
            int[] testC = new int[] { 1, 2, 3, 4, 5 };

            int[] testD = new int[] { 4, 4, 4, 4 };
            int[] testE = new int[] { };
            int[] testF = new int[] { 3, -1, 4, -5 };
            int[] testG = new int[] { 5, 3, 5, 2, 3 };

            List<int[]> intList = new List<int[]>();
            intList.Add(testA);
            intList.Add(testB);
            intList.Add(testC);

            intList.Add(testD);
            intList.Add(testE);
            intList.Add(testF);
            intList.Add(testG);*/

            // testA ================================= 
            /*Console.WriteLine("==== 개선 전 ====");
            Console.Write("정렬 전 > ");
            sort.PrintArray(testA);

            // 정렬 실행
            sort.BubbleSort(testA);

            Console.Write("정렬 후 > ");
            sort.PrintArray(testA);
            Console.WriteLine();

            testA = new int[] { 5, 3, 8, 4, 2 };

            Console.WriteLine("==== 개선 후 ====");
            Console.Write("정렬 전 > ");
            sort.PrintArray(testA);

            // 정렬 실행
            sort.BubbleSort2(testA);

            Console.Write("정렬 후 > ");
            sort.PrintArray(testA);
            Console.WriteLine();*/

            // testD ================================= 
            /*Console.WriteLine("==== 개선 전 ====");
            Console.Write("정렬 전 > ");
            sort.PrintArray(testD);
            
            // 정렬 실행
            sort.BubbleSort(testD);

            Console.Write("정렬 후 > ");
            sort.PrintArray(testD);
            Console.WriteLine();

            testA = new int[] { 5, 3, 8, 4, 2 };

            Console.WriteLine("==== 개선 후 ====");
            Console.Write("정렬 전 > ");
            sort.PrintArray(testD);

            // 정렬 실행
            sort.BubbleSort2(testD);

            Console.Write("정렬 후 > ");
            sort.PrintArray(testD);
            Console.WriteLine();*/

            /*foreach (int[] ints in intList)
            {
                Console.Write("정렬 전 > ");
                sort.PrintArray(ints);

                // 정렬 실행
                sort.BubbleSort(ints);

                Console.Write("정렬 후 > ");
                sort.PrintArray(ints);
                Console.WriteLine();
            }*/


            // 테스트 입력 배열들
            // 정수형 테스트 데이터
            int[] testA = new int[] { 5, 2, 4, 1, 3 };      // 기본 테스트: 랜덤한 숫자
            int[] testB = new int[] { 1, 2, 3, 4, 5 };      // 정렬된 입력
            int[] testC = new int[] { 5, 4, 3, 2, 1 };      // 역정렬 입력
            int[] testD = new int[] { 3, 1, 2, 3, 1 };      // 중복값 포함
            int[] testE = new int[] { 7, 7, 7, 7 };         // 모두 동일한 값
            int[] testF = new int[] { -2, 3, 0, -5 };       // 음수 포함
            int[] testG = new int[] { };                   // 빈 배열
            int[] testH = new int[] { 42 };                // 단일 요소

            // 정수형 테스트 리스트
            List<int[]> intTests = new List<int[]>
            {
                testA, testB, testC, testD, testE, testF, testG, testH
            };

            // 선택 정렬 실행
            foreach (var arr in intTests)
            {
                sort.SelectionSort(arr);
                Console.WriteLine($"[ {string.Join(", ", arr)} ]");
            }
        }
    }
}
