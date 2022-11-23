using UnityEngine;

public class Grid : MonoBehaviour
{
    private static readonly string[] WordsDatabase = new[]
    {
        "hello",
        "dance",
        "house",
        "cover",
    };
    
    private static readonly int RowLength = 5;
    
    private Row[] _nodes;
    
    private void Awake()
    {
        _nodes = new Row[5];
    }
    
}