using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk_gameobj : MonoBehaviour {

    public Chunk chunkData;

    public GameObject groundSectionPrefab;
    public Material groundMaterial;
    public List<GameObject> groundPieces;

	// Use this for initialization
	void Start () {
        BuildGroundMeshes();
        BuildColliders();
	}


    private void BuildGroundMeshes() {
        int vertexCount = 0;
        List<GameObject> groundArray = new List<GameObject>();

        foreach (Transform ground in transform) { 
            if (ground.name == "GroundPiece") {
                if (vertexCount < 50000) {
                    groundArray.Add(ground.gameObject);
                    vertexCount += ground.gameObject.GetComponent<MeshFilter>().mesh.vertexCount;
                }    
                else {
                    CombineMeshes(groundArray.ToArray());
                    vertexCount = 0;
                    groundArray = new List<GameObject>();
                }
            }
        }
        if (groundArray.Count > 0)
            CombineMeshes(groundArray.ToArray());
    }
    private void BuildColliders() {
        foreach (GameObject ground in groundPieces) {
            ground.AddComponent<MeshCollider>();
        }
    }

    private void CombineMeshes(GameObject[] array) {
        GameObject newGround = Instantiate(groundSectionPrefab, transform);
        CombineInstance[] combine = new CombineInstance[array.Length];

        for (int i = 0; i < array.Length; i++) {
            combine[i].mesh = array[i].GetComponent<MeshFilter>().sharedMesh;
            combine[i].transform = array[i].transform.localToWorldMatrix;
            Destroy(array[i]);
        }

        newGround.GetComponent<MeshFilter>().mesh = new Mesh();
        newGround.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        newGround.GetComponent<MeshRenderer>().material = groundMaterial;

        groundPieces.Add(newGround);
    }
}
