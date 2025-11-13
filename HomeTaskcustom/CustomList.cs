using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System;

namespace HomeTaskcustom
{
    internal class CustomList<T>
    {
        private T[] _array;
        public int Count { get; private set; }
        public int Capacity => _array.Length;

        public CustomList(int capacity = 4)
        {
            if (capacity < 0)
                throw new Exception("Capacity menfi ola bilmez");

            _array = new T[capacity];
        }

        private void EnsureCapacity(int size)
        {
            if (Capacity >= size) return;

            int newCapacity = Capacity == 0 ? 4 : Capacity * 2;
            while (newCapacity < size)
                newCapacity *= 2;

            T[] newArray = new T[newCapacity];
            for (int i = 0; i < Count; i++)
                newArray[i] = _array[i];

            _array = newArray;
        }

        public void Add(T item)
        {
            EnsureCapacity(Count + 1);
            _array[Count++] = item;
        }

        public void AddRange(T[] items)
        {
            if (items == null)
                throw new Exception("Array bos ola bilmez");

            EnsureCapacity(Count + items.Length);
            for (int i = 0; i < items.Length; i++)
                _array[Count++] = items[i];
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
                throw new Exception("Index duzgun deyil");

            EnsureCapacity(Count + 1);
            for (int i = Count; i > index; i--)
                _array[i] = _array[i - 1];

            _array[index] = item;
            Count++;
        }

        public void InsertRange(int index, T[] items)
        {
            if (items == null)
                throw new Exception("Array bos ola bilmez");
            if (index < 0 || index > Count)
                throw new Exception("Index araliga uyusmur");

            int insertCount = items.Length;
            if (insertCount == 0) return;

            EnsureCapacity(Count + insertCount);

            for (int i = Count - 1; i >= index; i--)
                _array[i + insertCount] = _array[i];

            for (int i = 0; i < insertCount; i++)
                _array[index + i] = items[i];

            Count += insertCount;
        }

        public T Find(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_array[i] != null && _array[i]!.Equals(value))
                    return _array[i];
            }
            return default!;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new Exception("Index duzgun deyil");

            for (int i = index; i < Count - 1; i++)
                _array[i] = _array[i + 1];

            _array[Count - 1] = default!;
            Count--;
        }

        private int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(_array[i], item))
                    return i;
            }
            return -1;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
                return false;

            RemoveAt(index);
            return true;
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
                _array[i] = default!;
            Count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new Exception("Index duzgun deyil");
                return _array[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new Exception("Index duzgun deyil");
                _array[index] = value;
            }
        }
    }
}
