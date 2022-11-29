using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VirtualKeyboard
{
    public class KeyboardButton : MonoBehaviour
    {

        public Vector2Int Position
        {
            get
            {
                var pos = transform.position;
                return new Vector2Int((int)pos.x, (int)pos.y);
            }
        }

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

        public Button Button => _button;
        
        internal Button.ButtonClickedEvent ClickedEvent => _button.onClick;

        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;
        private KeyCode _key;
        
        public override string ToString()
        {
            return _text.text;
        }

        public void SetKey(KeyCode key, string keyName)
        {
            Key = key;
            _text.text = string.IsNullOrEmpty(keyName) ? ToString() : keyName;
        }
        
    }
}