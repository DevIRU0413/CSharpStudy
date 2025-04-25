namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 큐는 선입선출(First In First Out - FIFO)의 자료구조
            // 대기열이라고도 한다. Queue라는 단어 자체가 표 같은 것을 구매하기 위해서 줄서는 것을 의미한다.
            // 스택과 비슷 하지만 조금 다르다.
            // 데이터가 들어오는 위치는 가장 뒤에 있고, 데이터가 나가는 위치는 가장 앞에 있어서, 먼저 들어오는 데이터가 먼저 나가게 된다.
            // 큐, 원형큐 등이 존재한다.

            // 주요 연산
            // Enqueue: 입력 동작
            // Dequeue: 출력 동작

            // 부가 연산
            // IsEmpty: 비어있는지 확인
            // IsFull: 꽉 차 있는지 확인
            // Peek: 앞에 있는 원소를 삭제하지 않고 반환
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("사과");
            queue.Enqueue("바나나");
            queue.Enqueue("체리");

            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Count);
        }

        public class Queue<T>
        {
            private T[] _items;
            private int _head; // dequeue 지점
            private int _tail; // enqueue 지점
            private int _count;

            public Queue()
            {
                _items = new T[4];
                _head = 0;
                _tail = 0;
                _count = 0;
            }

            public int Count => _count;

            public bool IsEmpty() => _count == 0;

            public void Enqueue(T item)
            {
                if (_count == _items.Length)
                    Resize();

                _items[_tail] = item;
                _tail = (_tail + 1) % _items.Length;
                _count++;
            }

            public T Dequeue()
            {
                if (IsEmpty())
                    throw new InvalidOperationException("큐가 비어있습니다.");

                T value = _items[_head];
                _items[_head] = default;
                _head = (_head + 1) % _items.Length;
                _count--;
                return value;
            }

            public T Peek()
            {
                if (IsEmpty())
                    throw new InvalidOperationException("큐가 비어있습니다.");
                return _items[_head];
            }

            private void Resize()
            {
                int newCapacity = _items.Length * 2;
                T[] newArray = new T[newCapacity];

                for (int i = 0; i < _count; i++)
                {
                    newArray[i] = _items[(_head + i) % _items.Length];
                }

                _items = newArray;
                _head = 0;
                _tail = _count;
            }
        }
    }
}
