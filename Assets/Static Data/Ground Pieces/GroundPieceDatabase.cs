using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ground Database", menuName = "Static Data/Ground Data")]
[ExecuteInEditMode]
public class GroundPieceDatabase : ScriptableObject {

    public GroundPiece[] straightPieces;
    public GroundPiece[] cornerPieces;

    public GroundPiece GetGroundPiece(GroundPiece.GroundType _groundType, int _index) {
        GroundPiece[] groundArray = null;

        switch (_groundType)
        {
            case GroundPiece.GroundType.Straight:
                groundArray = straightPieces;
                break;
            case GroundPiece.GroundType.Corner:
                groundArray = cornerPieces;
                break;
        }

        return groundArray[_index];
    }
    public int GetGroundTypeIndexMax(GroundPiece.GroundType _groundType) {
        int indexMax = 0;

        switch (_groundType)
        {
            case GroundPiece.GroundType.Straight:
                indexMax = straightPieces.Length - 1;
                break;
            case GroundPiece.GroundType.Corner:
                indexMax = cornerPieces.Length - 1;
                break;
        }

        return indexMax;
    }
}
