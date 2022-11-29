using System;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualKeyboard.Layout
{
    [Serializable]
    public class KeyboardLayoutRow
    {
        [SerializeField] public List<KeyboardLayoutButton> Buttons;
    }
}