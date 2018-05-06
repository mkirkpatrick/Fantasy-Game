using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPiece_gameobj : MonoBehaviour {

    public GrassPiece grasspieceData;

    public Vector2 windVelocity;

	// Use this for initialization
	void Start () {
        Material mat = new Material(Shader.Find("Diffuse"));
        mat.color = grasspieceData.baseColor;
        GetComponent<MeshRenderer>().material = mat;
    }
	
	// Update is called once per frame
	void Update () {
     
	}
}
