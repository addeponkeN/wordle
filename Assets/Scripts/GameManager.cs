using GameKeyboard;
using GameKeyboard.Layout;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Keyboard keyboard;

    private Grid _grid;

    private void Start()
    {
        var layout = new KeyboardLayoutStandard();
        keyboard.ApplyLayout(layout);

        _grid = new Grid();
    }

    private void Update()
    {
        
    }
    
}
