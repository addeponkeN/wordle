using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Util;

namespace WordGridSystem
{
    public class WordNode : MonoBehaviour
    {
        public char Character => _character;
        
        private char _character;
        
        [SerializeField] private Image _imgBackground;
        [SerializeField] private TMP_Text _lbChar;

        public void SetStatus(NodeStatus status)
        {
            var color = StatusHelper.GetStatusColor(status);
            SetColor(color);
        }

        private void SetColor(Color color)
        {
            _imgBackground.color = color;
        }

        public void Clear()
        {
            SetColor(Color.white);
            SetCharacter(' ');
        }

        public void SetCharacter(char character)
        {
            _character = character;
            _lbChar.text = _character.ToString();
        }
    }
}