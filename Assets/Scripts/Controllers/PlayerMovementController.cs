using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    public float moveSpeed;
    public float rotateSpeed;

    public float rotation;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rotation += rotateSpeed * Input.GetAxis("Mouse X");

        transform.Translate(moveHorizontal * moveSpeed * Time.deltaTime, 0, moveVertical * moveSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0f, rotation, 0f);
    }
}
