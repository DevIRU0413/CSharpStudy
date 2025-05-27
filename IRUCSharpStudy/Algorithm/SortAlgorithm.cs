namespace Algorithm
{
    internal class SortAlgorithm
    {
        public void BubbleSort(int[] arr)
        {
            int count = arr.Length;
            int temp = 0;
            for (int i = 1; i < count; i++)
            {
                Console.WriteLine($"Make a Round Count: {i}");
                for (int j = 0; j < count - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public void BubbleSort2(int[] arr)
        {
            int count = arr.Length;
            int temp = 0;
            bool  isSwap = false; // 교환 확인 변수
            for (int i = 1; i < count; i++)
            {
                isSwap = false;
                Console.WriteLine($"Make a Round Count: {i}");
                for (int j = 0; j < count - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        isSwap = true;
                    }
                }

                if (!isSwap) break; // 순회 시, 교환이 안 일어났다면 종료
            }
        }

        public void SelectionSort(int[] arr)
        {
            int count = arr.Length;

            int idx = 0;
            for (int i = 0; i < count - 1; i++)
            {
                idx = i;
                for (int j = i + 1; j < count; j++)
                {
                    if (arr[idx] > arr[j])
                        idx = j;
                }

                if (idx == i) continue;

                int temp = arr[idx];
                arr[idx] = arr[i];
                arr[i] = temp;
            }
        }

        public void PrintArray(int[] arr)
        {
            Console.Write("[");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if (i < arr.Length - 1) Console.Write(", ");
            }
            Console.WriteLine("]");
        }
    }
}
