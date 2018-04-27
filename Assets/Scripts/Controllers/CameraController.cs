using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float height;
    public float distance;
    public float angle;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 newPos = target.position + (target.forward * -distance);
        newPos += new Vector3(0, height, 0);

        transform.position = newPos;
        transform.LookAt(target);
	}
}
