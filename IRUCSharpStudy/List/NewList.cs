namespace List
{
    internal class NewList<T>
    {
        // 배열 기반 리스트
        // 추상적 자료형인 리스트를 배열을 사용하여 구현한 자료 구조다.

        // 저장 공간
        private T[] _items;
        private int _countPoint;

        public T this[int index]
        {
            get
            {
                if ((uint)index >= (uint)_countPoint)
                    throw new ArgumentOutOfRangeException(nameof(index), "인덱스가 리스트 범위를 벗어났습니다.");
                return _items[index];
            }

            set
            {
                if ((uint)index >= (uint)_countPoint)
                    throw new ArgumentOutOfRangeException(nameof(index), "인덱스가 리스트 범위를 벗어났습니다.");
                _items[index] = value;
            }
        }
        public int Count
        {
            get => _countPoint;
            private set
            {
                if (value > _items.Length)
                {
                    T[] temp = _items;
                    _items = new T[_items.Length * 2];

                    for (int i = 0; i < temp.Length; i++)
                        _items[i] = temp[i];
                }

                if (value >= 0)
                    _countPoint = value;
            }
        }
        public int Length => _items.Length;

        // 1. 빈 리스트를 만드는 연산
        public NewList()
        {
            _items = new T[4];
            Count = 0;
        }

        // 2. 리스트가 비어있는지 확인하는 연산
        public bool IsEmpty() => Count == 0;

        // 3. 리스트의 앞에 원소를 삽입하는 연산
        public void AddFirst(T item)
        {
            Count++;
            for (int i = Count - 1; i > 0; i--)
                _items[i] = _items[i - 1];

            _items[0] = item;
        }

        // 4. 리스트의 뒤에 원소를 삽입하는 연산
        public void AddLast(T item)
        {
            Count++;
            _items[Count - 1] = item;
        }

        // 5. 리스트의 원소를 지우는 연산
        public void RemoveAt(int index)
        {
            if (index < Count - 1)
                for (int i = index; i < Count; i++)
                    _items[i] = _items[i + 1];
            Count--;
        }

        // 6. 리스트의 제일 첫 원소를 알아보는 연산
        public T GetFirst() { return _items[0]; }

        // 7. 리스트의 첫 원소를 제외한 나머지 리스트를 알아보는 연산
        public NewList<T> GetRest()
        {
            NewList<T> reslut = new NewList<T>();
            for (int i = 1; i < Count; i++)
                reslut.AddLast(_items[i]);
            return reslut;
        }
    }
}
