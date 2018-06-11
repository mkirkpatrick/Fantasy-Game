using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="New Chunk", menuName = "Static Data/Chunk")]
public class Chunk : ScriptableObject {

    public int id;
    public Vector3 location;

    public List<GroundPiece> groundArray;
    public List<GrassPiece> grassArray;

    public Chunk() {
        groundArray = new List<GroundPiece>();
        grassArray = new List<GrassPiece>();
    }
}
