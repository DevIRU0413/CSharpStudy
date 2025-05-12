namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<string, int> dic = new MyDictionary<string, int>();

            dic.Add("apple", 1400);
            dic.Add("banana", 2200);
            dic.Add("bbanana", 2200);
            dic.Add("bbbanana", 2200);
            dic.Add("mango", 1600);
            dic.Add("aapple", 1230);
            dic.Add("aaapple", 1230);

            dic.PrintAll();
        }
    }

    public class MyDictionary<TKey, TValue>
    {
        private class Entry
        {
            public TKey Key;
            public TValue Value;
            public Entry Next;

            public Entry(TKey key, TValue value)
            {
                Key = key;
                Value = value;
                Next = null;
            }
        }

        private Entry[] buckets;
        private int capacity;

        public MyDictionary(int initialCapacity = 4)
        {
            capacity = initialCapacity;
            buckets = new Entry[capacity];
        }

        private int GetIndex(TKey key)
        {
            int hash = key.GetHashCode();
            int index = Math.Abs(hash) % capacity;
            return index;
        }

        public void Add(TKey key, TValue value)
        {
            int index = GetIndex(key);
            Entry current = buckets[index];

            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    current.Value = value;
                    return;
                }
                current = current.Next;
            }

            Entry newEntry = new Entry(key, value);
            newEntry.Next = buckets[index];
            buckets[index] = newEntry;
        }

        public TValue Get(TKey key)
        {
            int index = GetIndex(key);
            Entry current = buckets[index];

            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    return current.Value;
                }
                current = current.Next;
            }

            throw new Exception($"Key '{key}' not found.");
        }

        public void Remove(TKey key)
        {
            int index = GetIndex(key);
            Entry current = buckets[index];
            Entry prev = null;

            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    if (prev == null)
                        buckets[index] = current.Next;
                    else
                        prev.Next = current.Next;
                    return;
                }
                prev = current;
                current = current.Next;
            }
        }

        public bool ContainsKey(TKey key)
        {
            int index = GetIndex(key);
            Entry current = buckets[index];

            while (current != null)
            {
                if (current.Key.Equals(key))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void PrintAll()
        {
            for (int i = 0; i < capacity; i++)
            {
                Entry current = buckets[i];
                while (current != null)
                {
                    Console.WriteLine($"{current.Key}: {current.Value}");
                    current = current.Next;
                }
            }
        }
    }
}
