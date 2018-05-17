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

    private void BuildGrassMeshes(GameObject[] array) {

        int vertexCount = 0;
        List<Mesh> grassArray = new List<Mesh>();

        foreach (Transform ground in transform)
        {
            if (ground.name == "GroundPiece")
            {
                Mesh grassMesh = ground.transform.Find("Grass").GetComponent<MeshFilter>().sharedMesh;
                if (vertexCount < 50000)
                {
                    grassArray.Add(ground.gameObject);
                    vertexCount += grassMesh.vertexCount;
                }
                else
                {
                    CombineGroundMeshes(grassArray.ToArray());
                    vertexCount = 0;
                    grassArray = new List<GameObject>();
                }
            }
        }
    
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

    private void CombineMeshes(GameObject[] objArray, Material mat) {
        GameObject newSection = Instantiate(environmentSectionPrefab, transform);
        CombineInstance[] combine = new CombineInstance[objArray.Length];

        for (int i = 0; i < objArray.Length; i++)
        {
            combine[i].mesh = objArray[i].GetComponent<MeshFilter>().sharedMesh;
            combine[i].transform = objArray[i].transform.localToWorldMatrix;
        }

        newSection.GetComponent<MeshFilter>().mesh = new Mesh();
        newSection.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        newSection.GetComponent<MeshRenderer>().material = mat;

        groundPieces.Add(newSection);
    }
}
