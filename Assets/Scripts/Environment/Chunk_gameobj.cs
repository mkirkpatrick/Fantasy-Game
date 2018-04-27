using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk_gameobj : MonoBehaviour {

    public Chunk chunkData;

	// Use this for initialization
	void Start () {
        foreach (Transform ground in transform) {
            if (ground.name == "GroundPiece")
                ground.gameObject.AddComponent<MeshCollider>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmosSelected() {
        //Gizmos.DrawCube(transform.position, new Vector3(100, 5, 100));
    }
}
