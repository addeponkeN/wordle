using System.IO;
using UnityEngine;
using Util;
using VirtualKeyboard;
using WordGridSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Keyboard _keyboard;
    [SerializeField] private WordGrid _wordGrid;

    [SerializeField] private GameObject _gamePanelObj;
    [SerializeField] private GameObject _endPanelObj;

    private WordGridInputHandler _inputHandler;

    private void Awake()
    {
        _inputHandler = new WordGridInputHandler(_wordGrid, _keyboard);
        _wordGrid.SetWords(GeneratedWords.Items);
        _keyboard.ButtonClickedEvent.AddListener(Keyboard_OnButtonClickedEvent);
    }

    private void Start()
    {
        Begin();
    }

    private void Keyboard_OnButtonClickedEvent(KeyboardButton bt)
    {
        _inputHandler.HandleInput(bt.Key);

        bool isRoundEnded = _wordGrid.IsSolved || _wordGrid.ReachedEnd;

        if(isRoundEnded)
        {
            EndRound();
        }
    }

    private void EndRound()
    {
        _gamePanelObj.SetActive(false);
        _endPanelObj.SetActive(true);

        var endPanel = _endPanelObj.GetComponent<EndPanel>();

        bool isVictory = _wordGrid.IsSolved;

        endPanel.SetVictory(isVictory, _wordGrid.CurrentWord);
    }

    public void Begin()
    {
        _gamePanelObj.SetActive(true);
        _endPanelObj.SetActive(false);

        ResetKeyboardButtonColors();

        _wordGrid.NextRound();
    }

    private void ResetKeyboardButtonColors()
    {
        for(int i = 0; i < _keyboard.Buttons.Count; i++)
        {
            _keyboard.Buttons[i].SetStatus(NodeStatus.None);
        }
    }
}