using System;
using UnityEngine;

namespace VirtualKeyboard.Layout
{
    [Serializable]
    public struct KeyboardLayoutButton
    {
        public KeyCode Key;
        public GameObject Prefab;
    }
}