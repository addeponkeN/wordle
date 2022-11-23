using System;
using UnityEngine;

namespace GameKeyboard.Layout
{
    [Serializable]
    public class KeyboardLayoutRow
    {
        [SerializeField] public int Left;
        [SerializeField] public KeyCode[] Keys;
    }
}