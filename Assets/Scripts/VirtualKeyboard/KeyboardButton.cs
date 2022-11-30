using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VirtualKeyboard
{
    public class KeyboardButton : MonoBehaviour
    {
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

        internal Button.ButtonClickedEvent ClickedEvent => _button.onClick;

        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;
        
        private KeyCode _key;

        public void SetKey(KeyCode key, string keyName)
        {
            Key = key;
            _text.text = string.IsNullOrEmpty(keyName) ? ToString() : keyName;
        }
        
        public override string ToString()
        {
            return _text.text;
        }
    }
}