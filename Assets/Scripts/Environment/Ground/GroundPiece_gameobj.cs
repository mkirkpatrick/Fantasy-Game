using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPiece_gameobj : MonoBehaviour {

    public GroundPiece groundPieceData;

	// Use this for initialization
	void Start () {
        SetGroundPiece(groundPieceData);
	}

    public void SetGroundPiece(GroundPiece _groundPieceData) {
        GetComponent<MeshFilter>().mesh = _groundPieceData.groundMesh;
        GetComponent<MeshRenderer>().material = _groundPieceData.groundMaterial;
    }
}
