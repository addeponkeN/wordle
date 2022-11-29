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
    }
}