using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPiece_gameobj : MonoBehaviour {

    public GrassPiece grasspieceData;

    public Vector2 windVelocity;

    private GameObject baseCube;
    private GameObject[] segments;

	// Use this for initialization
	void Start () {
        segments = new GameObject[3];
        baseCube = transform.Find("Base").gameObject;
        segments[0] = baseCube.transform.GetChild(0).gameObject;
        segments[1] = segments[0].transform.GetChild(0).gameObject;
        segments[2] = segments[1].transform.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        float multiplier = 1;
        for(int i = 0; i < segments.Length; i++) {
            segments[i].transform.localPosition = new Vector3(windVelocity.x * multiplier, 1, windVelocity.y * multiplier);
            multiplier = 1f + ( ( (i * 2f) + 1) / 5f );
        }
	}
}
