using UnityEngine;
using Util;

namespace WordGrid
{
    public class Grid : MonoBehaviour
    {
        private static readonly int Rows = 5;
        
        private static readonly string[] WordsDatabase = new[]
        {
            "hello",
            "dance",
            "house",
            "cover",
        };
    
        private Row[] _rows;

        private int _currentRow;
        private int _currentColumn;
        private string _query;

        private string _currentWord;
    
        private void Awake()
        {
            _rows = new Row[Rows];
        }

        public void NextRound()
        {
            _currentWord = WordsDatabase.Random();
            _currentRow = 0;
            _currentColumn = 0;
        }

        public void AppendChar(char @char)
        {
            var row = _rows[_currentRow];
            var node = row[_currentColumn];

            node.Character = @char;

            row.SetNode(_currentColumn, node);
        }
        
    }

    public class Row
    {
        public Node this[int index] => _nodes[index];
        
        private Node[] _nodes;

        public Row()
        {
            _nodes = new Node[5];
        }

        public void SetNode(int i, Node node)
        {
            _nodes[i] = node;
        }
    }
    
    public enum NodeStatus
    {
        None,
        Yellow,
        Green,
    }
    
    public struct Node
    {
        public NodeStatus Status;
        public char Character;
    }
}