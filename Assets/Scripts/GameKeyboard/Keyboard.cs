using GameKeyboard.Layout;
using UnityEngine;

namespace GameKeyboard
{
    public class Keyboard : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabButton;
        [SerializeField] private GameObject _buttonsContainer;

        [SerializeField] private KeyboardLayout _keyboardLayout;
        
        private KeyboardRow[] _rows;

        private void Awake()
        {
            
        }

        public void ApplyLayout(IKeyboardLayoutGenerator layoutGenerator)
        {
            _keyboardLayout = layoutGenerator.Generate();

            for (int i = 0; i < _keyboardLayout.Row.Length; i++)
            {
                var row = _keyboardLayout.Row[i];
                AddButton(i, row.Keys.ToString());
            }

        }

        private void AddButton(int row, string text)
        {

        }

    }
}