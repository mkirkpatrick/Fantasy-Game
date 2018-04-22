using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ground Database", menuName = "Static Data/Ground Data")]
[ExecuteInEditMode]
public class GroundPieceDatabase : ScriptableObject {

    public GroundPiece[] flatPiece;
    public GroundPiece[] straightPieces;
    public GroundPiece[] cornerPieces;

    public GroundPiece GetGroundPiece(GroundPiece.GroundType _groundType, int _index) {
        GroundPiece[] groundArray = null;

        switch (_groundType)
        {
            case GroundPiece.GroundType.Flat:
                groundArray = flatPiece;
                break;
            case GroundPiece.GroundType.Straight:
                groundArray = straightPieces;
                break;
            case GroundPiece.GroundType.Corner:
                groundArray = cornerPieces;
                break;
        }

        return CloneGroundPiece(groundArray[_index]);
    }
    public int GetGroundTypeIndexMax(GroundPiece.GroundType _groundType) {
        int indexMax = 0;

        switch (_groundType)
        {
            case GroundPiece.GroundType.Flat:
                indexMax = 0;
                break;
            case GroundPiece.GroundType.Straight:
                indexMax = straightPieces.Length - 1;
                break;
            case GroundPiece.GroundType.Corner:
                indexMax = cornerPieces.Length - 1;
                break;
        }

        return indexMax;
    }

    private GroundPiece CloneGroundPiece(GroundPiece _groundPiece) {

        GroundPiece newGround = new GroundPiece(_groundPiece.index, _groundPiece.groundType);
        newGround.groundMaterial = _groundPiece.groundMaterial;
        newGround.groundMesh = _groundPiece.groundMesh;

        return newGround;
    }
}
