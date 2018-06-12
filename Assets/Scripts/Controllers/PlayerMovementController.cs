using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody rb;

    public float moveSpeed;
    public float rotateSpeed;

    public float jumpHeight;

    public float rotation;

    public static bool isSwimming;


    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start() {
    }

    // Check for water
    void OnTriggerEnter(Collider collider)
    {
        GameObject otherObj = collider.gameObject;

        if (otherObj.name == "Water") {
            rb.useGravity = false;
            isSwimming = true;
        }

    }
    void OnTriggerExit(Collider collider)
    {
        GameObject otherObj = collider.gameObject;
        if (otherObj.name == "Water")
        {
            rb.useGravity = true;
            isSwimming = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rotation += rotateSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;

        transform.Translate(moveHorizontal * moveSpeed * Time.deltaTime, 0, moveVertical * moveSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0f, rotation, 0f);

        //Jumping
        if ( Input.GetKeyDown("space") ) {
            rb.velocity += new Vector3(0, jumpHeight, 0);
        }
    }
}
