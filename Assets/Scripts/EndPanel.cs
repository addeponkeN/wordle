using TMPro;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _lbState;
    [SerializeField] private TMP_Text _lbWord;

    public void SetVictory(bool isVictory, string word)
    {
        _lbState.text = isVictory ? "VICTORY" : "DEFEAT";
        _lbWord.text = word;
    }
}
