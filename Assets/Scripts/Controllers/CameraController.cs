using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;
    public Transform target;

    public float height;
    public float distance;

    public float rotateSpeedX;
    public float rotateSpeedY;

    public float angle;
    public float yMinLimit = -40f;
    public float yMaxLimit = 80f;

    float x = 0.0f;
    float y = 0.0f;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        x += Input.GetAxis("Mouse X") * rotateSpeedX * distance * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * rotateSpeedY * Time.deltaTime;

        y = ClampAngle(y, yMinLimit, yMaxLimit);

        Quaternion rotation = Quaternion.Euler(y, x, 0);

        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + target.position;

        transform.rotation = rotation;
        transform.position = position;

        angle += rotateSpeedY * -Input.GetAxis("Mouse Y");
        transform.LookAt(target);
	}

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
