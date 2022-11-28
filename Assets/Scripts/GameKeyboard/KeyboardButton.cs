using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameKeyboard
{
    public class KeyboardButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;

        internal Button.ButtonClickedEvent ClickedEvent => _button.onClick;
        
        public Vector2Int Position
        {
            get
            {
                var pos = transform.position;
                return new Vector2Int((int)pos.x, (int)pos.y);
            }
        }
        
        private KeyCode _key;
        public KeyCode Key
        {
            get => _key; 
            set
            {
                _key = value;
                if(_text != null)
                {
                    _text.text = _key.ToString();
                }
            }
        }

        public override string ToString()
        {
            return _key.ToString();
        }

        public void SetKey(KeyCode key)
        {
            Key = key;
            _text.text = ToString();
        }
    }
}
