using GameKeyboard.Layout;
using UnityEngine;

namespace GameKeyboard
{
    public class Keyboard : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabButton;
        [SerializeField] private KeyboardLayout _keyboardLayout;
        
        private KeyboardRow[] _rows;

        private void Awake()
        {
            
        }

        public void ApplyLayout(KeyboardLayout layout)
        {
            
        }
        
    }
}