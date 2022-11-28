using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameKeyboard.Layout
{
    [Serializable]
    [CreateAssetMenu(
        fileName = "KeyboardLayout",
        menuName = "Virtual Keyboard Layout",
        order = 0)]
    public class KeyboardLayout : ScriptableObject
    {
        [SerializeField] public List<KeyboardLayoutRow> Rows;
    }

    [Serializable]
    public class KeyboardLayoutRow
    {
        [SerializeField] public List<KeyboardLayoutButton> Buttons;
    }
}