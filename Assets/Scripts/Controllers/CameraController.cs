using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;
    public Transform target;

    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    //public float offsetX = 1f;

    float x = 0.0f;
    float y = 0.0f;
    public float angle = 30;

    // Use this for initialization
    void Start() {
    
    }

    void LateUpdate() {

        angle -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

        //Clamp data
        angle = ClampAngle(angle, yMinLimit, yMaxLimit);
        distance = Mathf.Clamp(distance, distanceMin, distanceMax);

        float radians = Mathf.Deg2Rad * angle;

        x = Mathf.Cos(radians) * -distance;
        y = Mathf.Sin(radians) * distance;

        Vector3 newPos = player.position + (player.forward * x) + (player.up * y);

        transform.position = newPos;

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
