using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GroundPiece {
    public enum GroundType { Straight, Corner };

    public GroundType groundType;
    public int index;
    public Mesh groundMesh;
    public Material groundMaterial;
}
