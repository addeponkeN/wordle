using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameKeyboard.Layout
{
    [Serializable]
    public class KeyboardLayout
    {
        [SerializeField] public List<KeyboardButton> Buttons;
    }

}