using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GroundPiece {
    public enum GroundType { Flat, Straight, Corner };

    public int index;
    public GroundType groundType;
    public Mesh groundMesh;
    public Material groundMaterial;

    public GroundPiece(int _index, GroundType _groundType) {
        index = _index;
        groundType = _groundType;
    }
}
