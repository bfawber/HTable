using System.Collections.Generic;

namespace HTable
{
    public class HTbl<T, K>
    {
        private Dictionary<T, Stack<K>> data;
        public int Count
        {
            get;
            private set;
        }

        public HTbl()
        {
            this.data = new Dictionary<T, Stack<K>>();
        }

        public void Push(T key, K value)
        {
            if(data.ContainsKey(key))
            {
                this.data[key].Push(value);
            }
            else
            {
                this.data[key] = new Stack<K>();
                this.data[key].Push(value);
            }
            Count++;
        }

        public K Pop(T key)
        {
            if( this.data.ContainsKey(key) &&
                this.data[key] != null && 
               this.data[key].Count > 0)
            {
                Count--;
                return this.data[key].Pop();
            }
            else
            {
                return default(K);
            }
        }

        public bool IsEmpty()
        {
            if (Count > 0) return false;
            return true;
        }

        public bool Contains(K value)
        {
            foreach(Stack<K> stack in this.data.Values)
            {
                if (stack != null && stack.Count > 0)
                {
                    if (stack.Contains(value)) return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            Count = 0;
            this.data.Clear();
        }
    }
}
