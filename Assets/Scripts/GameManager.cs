using UnityEngine;
using VirtualKeyboard;
using WordGridSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Keyboard _keyboard;
    [SerializeField] private WordGrid _wordGrid;
    
    private WordGridInputHandler _inputHandler;

    private void Awake()
    {
        _inputHandler = new WordGridInputHandler(_wordGrid);
    }

    private void Start()
    {
        _keyboard.ButtonClickedEvent.AddListener(Keyboard_OnButtonClickedEvent);
    }

    private void Keyboard_OnButtonClickedEvent(KeyboardButton bt)
    {
        Debug.Log($"clicked button: {bt.Key}");
        _inputHandler.HandleInput(bt.Key);
    }

}