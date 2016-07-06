using System.Collections.Generic;

namespace HTable
{
    public class HTbl<T, K>
    {
        private Dictionary<T, Stack<K>> data;

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
        }

        public K Pop(T key)
        {
            if( this.data.ContainsKey(key) &&
                this.data[key] != null && 
               this.data[key].Count > 0)
            {
                return this.data[key].Pop();
            }
            else
            {
                return default(K);
            }
        }
    }
}
