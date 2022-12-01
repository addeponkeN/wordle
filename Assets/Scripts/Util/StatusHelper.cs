using UnityEngine;
using WordGridSystem;

namespace Util
{
    public class StatusHelper
    {
        public static Color GetStatusColor(NodeStatus status)
        {
            switch(status)
            {
                case NodeStatus.Yellow: return Color.yellow;
                case NodeStatus.Green: return Color.green;
                case NodeStatus.Dark: return Color.gray;
            }
            return Color.white;
        }
    }
}