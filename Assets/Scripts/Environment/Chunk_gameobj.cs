using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk_gameobj : MonoBehaviour {

    public Chunk chunkData;

    public GameObject environmentSectionPrefab;
    public Material groundMaterial;
    public List<GameObject> groundPieces;
    public List<GameObject> grassPieces;

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
                    CombineGroundMeshes(groundArray.ToArray());
                    vertexCount = 0;
                    groundArray = new List<GameObject>();
                }
            }
        }
        if (groundArray.Count > 0)
            CombineGroundMeshes(groundArray.ToArray());
    }
    private void BuildColliders() {
        foreach (GameObject ground in groundPieces) {
            ground.AddComponent<MeshCollider>();
        }
    }

    private void CombineGroundMeshes(GameObject[] array) {
        GameObject newGround = Instantiate(environmentSectionPrefab, transform);
        CombineInstance[] combine = new CombineInstance[array.Length];

        for (int i = 0; i < array.Length; i++) {
            combine[i].mesh = array[i].GetComponent<MeshFilter>().sharedMesh;
            combine[i].transform = array[i].transform.localToWorldMatrix;
            Destroy(array[i]);
        }

        newGround.GetComponent<MeshFilter>().mesh = new Mesh();
        newGround.GetComponent<MeshFilter>().mesh.CombineMeshes(combine, false);
        //newGround.GetComponent<MeshRenderer>().material = groundMaterial;

        groundPieces.Add(newGround);
    }

    private void CombineGrassMeshes(GameObject[] grassArray)
    {
        GameObject newGrass = Instantiate(environmentSectionPrefab, transform);
        CombineInstance[] combine = new CombineInstance[grassArray.Length];

        for (int i = 0; i < grassArray.Length; i++)
        {
            combine[i].mesh = grassArray[i].GetComponent<MeshFilter>().sharedMesh;
            combine[i].transform = grassArray[i].transform.localToWorldMatrix;
            Destroy(grassArray[i]);
        }

        newGrass.GetComponent<MeshFilter>().mesh = new Mesh();
        newGrass.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        newGrass.GetComponent<MeshRenderer>().material = groundMaterial;

        groundPieces.Add(newGrass);
    }
}
