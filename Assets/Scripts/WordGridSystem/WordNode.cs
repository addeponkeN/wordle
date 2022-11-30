using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WordGridSystem
{
    public class WordNode : MonoBehaviour
    {
        private static Color GetStatusColor(NodeStatus status)
        {
            switch(status)
            {
                case NodeStatus.Yellow: return Color.yellow;
                case NodeStatus.Green: return Color.green;
                case NodeStatus.Dark: return Color.gray;
            }
            return Color.white;
        }

        [SerializeField] private Image _imgBackground;
        [SerializeField] private TMP_Text _lbChar;

        private char _character;

        public char Character => _character;

        public void SetStatus(NodeStatus status)
        {
            var color = GetStatusColor(status);
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