using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPieceData : ScriptableObject {
    public enum GroundType { Straight, Corner};
    public int index;
    public Mesh groundMesh;

}
