using System.Linq;
using UnityEngine;

namespace WordGridSystem
{
    public class WordGridInputHandler
    {
        private WordGrid _grid;

        public WordGridInputHandler(WordGrid grid)
        {
            _grid = grid;
        }

        public void HandleInput(KeyCode key)
        {
            switch(key)
            {
                case KeyCode.Backspace:
                {
                    _grid.Backspace();
                    break;
                }

                case KeyCode.Return:
                {
                    _grid.TrySolve();
                    break;
                }

                default:
                {
                    var chr = key.ToString().First();
                    _grid.AppendChar(chr);
                    break;
                }
            }
        }
    }
}