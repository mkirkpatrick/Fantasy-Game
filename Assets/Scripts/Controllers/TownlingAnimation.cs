using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownlingAnimation : MonoBehaviour {
    public Animator Anim;
    private float VerticalSpeed;
	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
        float moveVertical = Input.GetAxis("Vertical");

        Anim.SetFloat("VerticalSpeed", moveVertical);
	}
}
