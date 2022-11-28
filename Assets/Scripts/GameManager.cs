using System.Linq;
using GameKeyboard;
using UnityEngine;
using Grid = WordGrid.Grid;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Keyboard _keyboard;

    private Grid _grid;

    private void Start()
    {
        _keyboard.ButtonClickedEvent.AddListener(Keyboard_OnButtonClickedEvent);
    }

    private void Keyboard_OnButtonClickedEvent(KeyboardButton bt)
    {
        var character = bt.Key.ToString().First();
        _grid.AppendChar(character);
    }
    
}
