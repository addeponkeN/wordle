using System.Collections.Generic;
using UnityEngine;

namespace GameKeyboard.Layout
{
    public class KeyboardLayoutStandard : IKeyboardLayoutGenerator
    {
        private static List<KeyCode>[] _rows =
        {
            new()
            {
                KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O,
                KeyCode.P
            },
            new()
            {
                KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L,
            },
            new()
            {
                KeyCode.Return, KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M,
                KeyCode.Backspace
            }
        };


        public KeyboardLayout Generate()
        {
            const int rowLength = 3;

            var layout = new KeyboardLayout();
            layout.Row = new KeyboardLayoutRow[rowLength];

            for(int i = 0; i < rowLength; i++)
            {
                var rowData = _rows[i];

                var layoutRow = new KeyboardLayoutRow();
                layoutRow.Keys = rowData.ToArray();

                layout.Row[i] = layoutRow;
            }

            return layout;
        }
    }
}