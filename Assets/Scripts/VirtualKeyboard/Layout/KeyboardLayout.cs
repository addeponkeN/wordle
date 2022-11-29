using System;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualKeyboard.Layout
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


}