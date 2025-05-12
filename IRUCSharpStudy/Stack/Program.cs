namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 스택은 제한적으로 접근할 수 있는 나열 구조이다.
            // 그 접근 방법은 언제나 목록의 끝에서만 일어난다.
            // 스택은 한 쪽 끝에서만 자료를 넣거나 뺄 수 있는 선형 및 후입 선출 구조로 되어 있다.
            // 자료를 넣는 것을 '밀어넣다' 하여 푸쉬라고 하고, 반대로 넣어둔 자료를 꺼내는 것을 팝이라고 하는데, 이때 나중에 넣은 값이 먼저 나온다.
            // 데이터 접근의 특징은 Last In First Out이다. 약자는 LIFO 이다.

            // - top(peek): 가장 윗 데이터를 반환, 만약 스택이 비었다면 이 연산은 정의 불가 상태이다.
            // - pop: 가장 윗 데이터를 삭제한다. 스택이 비었다면 연산 정의 불가 상태.
            // - push: 가장 윗 데이터로 top이 가리키는 자리 위에 메모리를 생성하고 데이터를 넣어준다.
            // - empty: 스택이 비었다면 1을 반환하고, 그렇지 않을 경우면 0일 반환한다.

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Print();


            Console.WriteLine("Top " + stack.Top());
            Console.WriteLine("Pop " + stack.Pop());
            Console.WriteLine("Pop " + stack.Pop());
            Console.WriteLine("Top " + stack.Top());
            stack.Print();

            Console.WriteLine("Contains 3: " + stack.Contains(3));
            Console.WriteLine("Contains 2: " + stack.Contains(2));
            stack.Print();
        }

    }

    public class Stack<T>
    {
        private T[] _items;
        private int _count;
        private int TopIndex => _count - 1;

        public int Count => _count;

        public Stack()
        {
            _items = new T[4];
        }

        public T Top()
        {
            if (IsEmpty())
                throw new InvalidOperationException("큐가 비어있습니다.");

            return _items[TopIndex];
        }
        public T Peek()
        {
            return Top();
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("큐가 비어있습니다.");

            T returnValue = _items[TopIndex];
            _items[TopIndex] = default;
            _count--;
            return returnValue;
        }

        public void Push(T t)
        {
            _count++;
            if (_items.Length < _count)
            {
                int length = _items.Length * 2;
                T[] oldArr = _items;
                _items = new T[length];
                for (int i = 0; i < _count - 1; i++)
                    _items[i] = oldArr[i];
            }
            _items[TopIndex] = t;
        }

        public bool IsEmpty()
        {
            return _count <= 0;
        }

        public bool Contains(T value)
        {
            if (IsEmpty()) return false;
            for (int i = 0; i < _count; i++)
                if (_items[i].Equals(value))
                    return true;

            return false;
        }

        public void Clear()
        {
            for(int i = 0; i < _items.Length; i++)
                Pop();
        }

        public void Print()
        {
            if (IsEmpty())
                throw new InvalidOperationException("큐가 비어있습니다.");

            Console.WriteLine();
            Console.WriteLine("Low");
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(_items[i]);
            }
            Console.WriteLine("High");
            Console.WriteLine();
        }
    }
}
