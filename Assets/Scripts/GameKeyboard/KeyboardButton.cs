using TMPro;
using UnityEngine;

namespace GameKeyboard
{
    public class KeyboardButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

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
    }
}
