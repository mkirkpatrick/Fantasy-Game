using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Chunk {

    public int id;
    public Vector3 location;

    public List<GroundPiece> groundArray;
    public List<GrassPiece> grassArray;
}
