using System.Collections.Generic;

namespace Util
{
    public class DistinctList<T>
    {
        public T this[int index] => _list[index];

        private List<T> _list = new();
        private HashSet<T> _set = new();

        public List<T> Items => _list;
        
        public void Add(T item)
        {
            if(_set.Contains(item))
                return;
            
            _list.Add(item);
            _set.Add(item);
        }

        public void Remove(T item)
        {
            _list.Remove(item);
            _set.Remove(item);
        }

        public void Clear()
        {
            _list.Clear();
            _set.Clear();
        }
        
    }
}