using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk_gameobj : MonoBehaviour {

    public Chunk chunkData;

    public GameObject environmentSectionPrefab;
    public Material[] groundMaterials;
    public List<GameObject> groundPieces;
    public List<GameObject> grassPieces;

	// Use this for initialization
	void Start () {
        BuildGroundMeshes();
        BuildCliffMeshes();
        BuildPathMeshes();
        BuildColliders();

        //After consolidating ground meshes, destroy old building blocks
        DestroyGroundPieces();
	}

    //Mesh Builders by group
    private void BuildGroundMeshes() {

        int vertexCount = 0;
        List<GameObject> groundArray = new List<GameObject>();

        foreach (Transform ground in transform)
        {
            if (ground.name == "GroundPiece")
            {
                GameObject groundObj = ground.Find("Ground").gameObject;

                if (vertexCount > 50000)
                {
                    CombineMeshes(groundArray.ToArray(), groundMaterials[0]);
                    vertexCount = 0;
                    groundArray = new List<GameObject>();
                }

                groundArray.Add(groundObj);
                vertexCount += groundObj.GetComponent<MeshFilter>().sharedMesh.vertexCount;
            }
        }
        if(groundArray.Count > 0)
            CombineMeshes(groundArray.ToArray(), groundMaterials[0]);
    }

    private void BuildCliffMeshes()
    {

        int vertexCount = 0;
        List<GameObject> cliffArray = new List<GameObject>();

        foreach (Transform ground in transform)
        {

            if (ground.name == "GroundPiece") {
                GroundPiece.GroundType groundType = ground.gameObject.GetComponent<GroundPiece_gameobj>().groundPieceData.groundType;

                if (groundType == GroundPiece.GroundType.Straight || groundType == GroundPiece.GroundType.Corner || groundType == GroundPiece.GroundType.Ramp) {

                    GameObject cliffObj = ground.Find("Cliff").gameObject;

                    if (vertexCount > 50000)
                    {
                        CombineMeshes(cliffArray.ToArray(), groundMaterials[1]);
                        vertexCount = 0;
                        cliffArray = new List<GameObject>();
                    }

                    cliffArray.Add(cliffObj);
                    vertexCount += cliffObj.GetComponent<MeshFilter>().sharedMesh.vertexCount;
                }
            }
        }
        if (cliffArray.Count > 0)
            CombineMeshes(cliffArray.ToArray(), groundMaterials[1]);
    }

    private void BuildPathMeshes()
    {

        int vertexCount = 0;
        List<GameObject> pathArray = new List<GameObject>();

        foreach (Transform ground in transform) {

            if (ground.name == "GroundPiece") {
                GroundPiece.GroundType groundType = ground.gameObject.GetComponent<GroundPiece_gameobj>().groundPieceData.groundType;

                if (groundType == GroundPiece.GroundType.Path) {

                    GameObject pathObj = ground.Find("Dirt").gameObject;

                    if (vertexCount > 50000) {
                        CombineMeshes(pathArray.ToArray(), groundMaterials[2]);
                        vertexCount = 0;
                        pathArray = new List<GameObject>();
                    }

                    pathArray.Add(pathObj);
                    vertexCount += pathObj.GetComponent<MeshFilter>().sharedMesh.vertexCount;
                }
            }
        }
        if (pathArray.Count > 0)
            CombineMeshes(pathArray.ToArray(), groundMaterials[2]);
    }
    //Utility functions
    private void CombineMeshes(GameObject[] objArray, Material mat) {
        GameObject newSection = Instantiate(environmentSectionPrefab, transform);
        newSection.name = "Ground Section";

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

    private void BuildColliders()
    {
        foreach (GameObject ground in groundPieces)
        {
            ground.AddComponent<MeshCollider>();
        }
    }

    private void DestroyGroundPieces() {
        foreach (Transform ground in transform)
        {
            if(ground.name == "GroundPiece")
                Destroy(ground.gameObject);
        }
    }
}
