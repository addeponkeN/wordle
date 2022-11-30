using System;
using System.Linq;
using UnityEngine;
using Util;

namespace WordGridSystem
{
    public enum NodeStatus
    {
        None,
        Yellow,
        Green,
        Dark,
    }

    public class WordGrid : MonoBehaviour
    {
        private static readonly int MaxRows = 5;
        private static readonly int MaxColumns = 5;

        public bool IsSolved;
        public string CurrentWord => _currentWord;
        public bool ReachedEnd => _currentColumnIndex >= MaxRows;

        private Row CurrentRow => _rows[_currentRowIndex];
        private WordNode CurrentNode => CurrentRow[_currentColumnIndex];

        [SerializeField] private GameObject _prefabWordNode;
        [SerializeField] private float _spacing = 4;

        private Row[] _rows;
        private string[] _words;
        private int _currentRowIndex;
        private int _currentColumnIndex;
        private string _currentWord;

        private void Awake()
        {
            _rows = new Row[MaxRows];

            var tf = transform;

            var nodeRect = _prefabWordNode.GetComponent<RectTransform>().rect;

            for(int i = 0; i < MaxRows; i++)
            {
                var wordRowObject = new GameObject($"Row {i}");
                wordRowObject.transform.parent = tf;

                var pos = tf.position;

                var row = new Row();
                _rows[i] = row;

                for(int j = 0; j < MaxColumns; j++)
                {
                    var nodePosition = pos + new Vector3(
                        j * _spacing + j * nodeRect.width,
                        i * -_spacing + i * -nodeRect.height);

                    var nodeObject = Instantiate(_prefabWordNode, nodePosition, Quaternion.identity,
                        wordRowObject.transform);
                    var wordNode = nodeObject.GetComponent<WordNode>();
                    row[j] = wordNode;
                }
            }
        }

        private void SetRandomWord()
        {
            _currentWord = _words.Random();
        }

        private void ResetGrid()
        {
            for(int i = 0; i < _rows.Length; i++)
            {
                _rows[i].Clear();
            }
        }

        public void NextRound()
        {
            ResetGrid();
            IsSolved = false;
            _currentRowIndex = 0;
            _currentColumnIndex = 0;
            
            SetRandomWord();

            Debug.Log($"new round - current word: {_currentWord}");
        }

        public void AppendChar(char @char)
        {
            if(_currentColumnIndex >= MaxColumns)
            {
                return;
            }

            CurrentNode.SetCharacter(@char);

            _currentColumnIndex++;
        }

        public void Backspace()
        {
            if(_currentColumnIndex <= 0)
            {
                return;
            }

            _currentColumnIndex--;

            CurrentNode.Clear();
        }

        public bool TrySolve()
        {
            if(_currentColumnIndex < MaxColumns)
            {
                Debug.Log($"cant solve - missing characters ({_currentColumnIndex} / {MaxColumns})");
                return false;
            }

            Solve();

            NextRow();

            return true;
        }

        private void NextRow()
        {
            _currentRowIndex++;
            _currentColumnIndex = 0;
        }

        private void Solve()
        {
            var row = _rows[_currentRowIndex];

            int correctCharacterCount = 0;

            for(int i = 0; i < MaxColumns; i++)
            {
                var node = row[i];

                var character = char.ToLower(node.Character);

                if(IsCharacterCorrect(i, character))
                {
                    node.SetStatus(NodeStatus.Green);
                    correctCharacterCount++;
                }
                else if(IsCharacterInWord(character))
                {
                    node.SetStatus(NodeStatus.Yellow);
                }
                else
                {
                    node.SetStatus(NodeStatus.Dark);
                }
            }

            IsSolved = correctCharacterCount >= MaxColumns;
        }

        private bool IsCharacterCorrect(int index, char character)
        {
            return _currentWord[index].Equals(character);
        }

        private bool IsCharacterInWord(char character)
        {
            return _currentWord.Contains(character);
        }

        public void SetWords(string[] word)
        {
            _words = word;
        }
    }
}