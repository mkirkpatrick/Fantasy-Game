using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ground Database", menuName = "Static Data/Ground Data")]
[ExecuteInEditMode]
public class GroundPieceDatabase : ScriptableObject {

    public Material[] materials;

    public GameObject[] flatPiece;
    public GameObject[] straightPieces;
    public GameObject[] cornerPieces;
    public GameObject[] rampPieces;
    public GameObject[] pathPieces;

    public GameObject GetGroundPiece(GroundPiece.GroundType _groundType, int _index) {
        GameObject[] groundArray = null;

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
            case GroundPiece.GroundType.Ramp:
                groundArray = rampPieces;
                break;
            case GroundPiece.GroundType.Path:
                groundArray = pathPieces;
                break;
        }

        return CloneGroundPiece(_groundType, _index, groundArray[_index]);
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
            case GroundPiece.GroundType.Ramp:
                indexMax = rampPieces.Length - 1;
                break;
            case GroundPiece.GroundType.Path:
                indexMax = pathPieces.Length - 1;
                break;
        }

        return indexMax;
    }

    private GameObject CloneGroundPiece(GroundPiece.GroundType _groundType, int _index, GameObject groundObj) {

        GameObject newObj = Instantiate(groundObj);
        newObj.name = "GroundPiece";

        return newObj;
    }
}
