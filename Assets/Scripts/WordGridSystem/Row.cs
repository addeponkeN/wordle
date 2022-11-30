using System.Linq;

namespace WordGridSystem
{
    public class Row
    {
        public WordNode this[int index]
        {
            get => _nodes[index];
            set => _nodes[index] = value;
        }

        private WordNode[] _nodes;

        public Row()
        {
            _nodes = new WordNode[5];
        }

        public string GetWord()
        {
            return new string(_nodes.Select(x => x.Character).ToArray());
        }

        public void Clear()
        {
            for(int i = 0; i < _nodes.Length; i++)
            {
                _nodes[i].Clear();
            }
        }
    }
}