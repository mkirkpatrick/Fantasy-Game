using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkController : MonoBehaviour
{

    public Chunk[] chunks;
    public List<GameObject> currentChunkObjects;

    //Prefabs
    public GameObject chunkPrefab;

    // Use this for initialization
    void Start()
    {
        currentChunkObjects.Add(LoadChunk(chunks[0]));
    }

    public GameObject LoadChunk(Chunk chunkData)
    {
        GameObject newChunk = Instantiate(chunkPrefab);
        newChunk.GetComponent<Chunk_gameobj>().chunkData = chunkData;
        newChunk.gameObject.transform.position = chunkData.location;

        LoadGround(newChunk.GetComponent<Chunk_gameobj>(), chunkData);

        return newChunk;
    }

    private void LoadGround(Chunk_gameobj chunkObj, Chunk chunkData) {

        foreach (GroundPiece ground in chunkData.groundArray)
        {
            GameObject newGround = GameController.instance.staticDB.groundPieceData.GetGroundPiece(ground.groundType, ground.index);
            newGround.GetComponent<GroundPiece_gameobj>().groundPieceData = ground;
            newGround.transform.parent = chunkObj.transform;
            newGround.transform.position = ground.location;
            newGround.transform.localScale = new Vector3(ground.xScale, 1, ground.yScale);
            newGround.transform.eulerAngles = new Vector3(0, ground.rotation, 0);

            chunkObj.groundPieces.Add(newGround);
        }
    }

}
