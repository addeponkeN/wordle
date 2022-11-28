using System;
using GameKeyboard.Layout;
using UnityEngine;
using UnityEngine.Events;
using SF = UnityEngine.SerializeField;

namespace GameKeyboard
{
    public class Keyboard : MonoBehaviour
    {
        [Space(5)]
        
        [SF] private GameObject _prefabButton;
        [SF] private GameObject _buttonsContainer;

        [Space(5)]
        
        [SF] private KeyboardLayout _keyboardLayout;
        [SF] private float _spacing = 2;

        [Space(20)]
        
        public UnityEvent<KeyboardButton> ButtonClickedEvent;

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
            var buttonRec = _prefabButton.GetComponent<RectTransform>().rect;
            var keyboardPosition = transform.position;
            
            for(int i = 0; i < _keyboardLayout.Rows.Count; i++)
            {
                var row = _keyboardLayout.Rows[i];
                for(int j = 0; j < row.Buttons.Count; j++)
                {
                    var button = row.Buttons[j];
                    
                    var position = new Vector2Int(
                        (int)(keyboardPosition.x + j * buttonRec.width + j * _spacing),
                        (int)(keyboardPosition.y + i * -_spacing + i * -buttonRec.height));
                    
                    AddButton(button.Key, position);
                }
            }
        }

        /// <summary>
        /// Add button to the keyboard
        /// </summary>
        /// <param name="key"></param>
        /// <param name="position"></param>
        private void AddButton(KeyCode key, Vector2Int position)
        {
            var tf = _buttonsContainer.transform;
            
            var objButton = Instantiate(_prefabButton, new Vector3(position.x, position.y), Quaternion.identity, tf);
            
            var button = objButton.GetComponent<KeyboardButton>();
            button.SetKey(key);
            
            objButton.name = $"Button {button}";
            
            button.ClickedEvent.AddListener(() => OnButtonClicked(button));
        }

        private void OnButtonClicked(KeyboardButton bt)
        {
            Debug.Log($"clicked button: {bt}");
            ButtonClickedEvent?.Invoke(bt);
        }
        
    }
}