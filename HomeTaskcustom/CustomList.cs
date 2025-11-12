using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTaskcustom
{
    internal class CustomList
    {
        public object[] _array;
        public int Count { get; private set; }
        public int Capacity { get { return _array.Length; } }

        public CustomList(int capacity = 4)
        {
            if (capacity < 0)
            {
                throw new Exception("Capacity menfi olammaz");

            }
            _array = new object[capacity];
        }


        public void AddCapacity(int num)
        {
            if (Capacity < num)
            {
                int newCapacity = Capacity;
                if (newCapacity < 1)
                {
                    newCapacity = 4;
                }
                else
                {
                    newCapacity = newCapacity * 2;
                }

                object[] newArray = new object[newCapacity];
                for (int i = 0; i < Count; i++)
                    newArray[i] = _array[i];
                _array = newArray;
            }
        }


        public void Add(object[] item)
        {
            if (item == null)
            {
                throw new Exception("Bos ola bilmez");
            }
            AddCapacity(Count + item.Length);
            for (int i = 0; i < item.Length; i++)
            {
                _array[Count] = item[i];
                Count++;
            }

        }


        public void AddRange(object[] items)
        {
            if (items == null)
                throw new Exception("Array bos olammaz");

            AddCapacity(Count + items.Length);
            for (int i = 0; i < items.Length; i++)
            {
                _array[Count] = items[i];
                Count++;
            }
        }


        public void Insert(int index, object item)
        {
            if (index < 0 || index > Count)
                throw new Exception("Index duzgun deyil");

            AddCapacity(Count + 1);

            for (int i = Count; i > index; i--)
                _array[i] = _array[i - 1];

            _array[index] = item;
            Count++;
        }

        public void InsertRange(int index, object[] items)
        {
            if (items == null)
                throw new Exception("Array bos ola bilmez");
            if (index < 0 || index > Count)
                throw new Exception("Index araliga uyusmur");

            int insertCount = items.Length;
            if (insertCount == 0)
                return;

            AddCapacity(Count + insertCount);

            for (int i = Count - 1; i >= index; i--)
                _array[i + insertCount] = _array[i];

            for (int i = 0; i < insertCount; i++)
                _array[index + i] = items[i];

            Count += insertCount;
        }

        public object Find(object value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_array[i] != null && _array[i].Equals(value))
                    return _array[i];
            }
            return null;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new Exception("Index duzgun deyil");

            for (int i = index; i < Count - 1; i++)
                _array[i] = _array[i + 1];

            _array[Count - 1] = null;
            Count--;
        }

        private int IndexOf(object item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(_array[i], item))
                    return i;
            }
            return -1;
        }

        public bool Remove(object item)
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
                _array[i] = null;
            Count = 0;
        }

        public object this[int index]
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
