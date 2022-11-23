using System;
using UnityEngine;

namespace GameKeyboard.Layout
{
    [Serializable]
    public class KeyboardLayout
    {
        [SerializeField] public KeyboardLayoutRow[] Row;
    }

}