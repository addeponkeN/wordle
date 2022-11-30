using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using VirtualKeyboard.Layout;
using SF = UnityEngine.SerializeField;

namespace VirtualKeyboard
{
    public class Keyboard : MonoBehaviour
    {
        //  Inspector layout
        
        [Space(5)]
        
        [SF] private GameObject _prefabButtonDefault;
        [SF] private GameObject _buttonsContainer;

        [Space(5)]
        
        [SF] private KeyboardLayout _keyboardLayout;
        [SF] private float _spacing = 2;

        [Space(20)]
        
        public UnityEvent<KeyboardButton> ButtonClickedEvent;
        
        //  -----

        //  Fields & Properties

        public List<KeyboardButton> Buttons => _buttons;

        private List<KeyboardButton> _buttons;

        private void Awake()
        {
            _buttons = new();
        }

        private void Start()
        {
            ApplyLayout();
        }

        public void SetLayout(KeyboardLayout layout)
        {
            _keyboardLayout = layout;
            ApplyLayout();
        }
        
        private void ApplyLayout()
        {
            _buttons.Clear();
            
            var keyboardPosition = transform.position;
            var sharedButtonHeight = _prefabButtonDefault.GetComponent<RectTransform>().rect.height;
            
            for(int i = 0; i < _keyboardLayout.Rows.Count; i++)
            {
                var row = _keyboardLayout.Rows[i];

                int offsetX = 0;
                
                for(int j = 0; j < row.Buttons.Count; j++)
                {
                    var button = row.Buttons[j];

                    var position = new Vector2Int(
                        (int)(keyboardPosition.x + offsetX + j * _spacing),
                        (int)(keyboardPosition.y + i * -_spacing + i * -sharedButtonHeight));
                    
                    var buttonObject = AddButton(button, position);

                    var buttonRect = buttonObject.GetComponent<RectTransform>().rect;
                    offsetX += (int)buttonRect.width;
                }
            }
        }

        /// <summary>
        /// Add button to the keyboard
        /// </summary>
        private GameObject AddButton(KeyboardLayoutButton layoutButton, Vector2Int position)
        {
            var tf = _buttonsContainer.transform;

            var prefab = layoutButton.Prefab ? layoutButton.Prefab : _prefabButtonDefault;
            
            var objButton = Instantiate(prefab, new Vector3(position.x, position.y), Quaternion.identity, tf);
            
            var button = objButton.GetComponent<KeyboardButton>();
            _buttons.Add(button);

            var prefabKeyName = prefab.GetComponentInChildren<TMP_Text>();
            
            button.SetKey(layoutButton.Key, prefabKeyName.text);
            
            objButton.name = $"Button {button}";
            
            button.ClickedEvent.AddListener(() => OnButtonClicked(button));
            

            return objButton;
        }

        private void OnButtonClicked(KeyboardButton bt)
        {
            ButtonClickedEvent?.Invoke(bt);
        }
        
    }
}