using System;
using System.Linq;
using UnityEngine;
using VirtualKeyboard;

namespace WordGridSystem
{
    public class WordGridInputHandler
    {
        private WordGrid _grid;
        private Keyboard _keyboard;

        public WordGridInputHandler(WordGrid grid, Keyboard kb)
        {
            _grid = grid;
            _keyboard = kb;
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

                    var guessedCharacters = _grid.GuessedCharacters;

                    for(int i = 0; i < guessedCharacters.Count; i++)
                    {
                        var ch = guessedCharacters[i];

                        string character = char.ToUpper(ch.Character).ToString();
                        
                        if(!Enum.TryParse(character, out KeyCode guessedKey))
                            continue;
                        
                        var button = _keyboard.GetButton(guessedKey);
                        button.SetStatus(ch.Status);
                    }
                    
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