using UnityEngine;
using UnityEditor;

public class GroundPieceDataAsset
{
    [MenuItem("Assets/Create/Scriptable Object/Ground Piece")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<GroundPieceData>();
    }
}
