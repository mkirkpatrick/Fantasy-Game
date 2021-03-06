﻿using System.Collections;
using UnityEngine;

public class HumanAnimationsController : MonoBehaviour {
    public Animator anim;
    private float randomJump;
    //public GameObject pmc;
	void Start () {
        anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // Get speed from user input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Update the animator with speed
        anim.SetFloat("HorizontalSpeed", moveHorizontal);
        anim.SetFloat("VerticalSpeed", moveVertical);

        //pmc = PlayerMovementController.isSwimming;
        //pmc.GetComponent<PlayerMovementController>();
        //if (pmc.isSwimming == true) {
        //    pmc.Anim.SetBool("isSwimming", true);
        //} else {
        //    pmc.Anim.SetBool("isSwimming", false);
        //}

        if (Input.GetKeyDown("space"))
        {
            randomJump = Random.Range(0f, 1f);
            Debug.Log(randomJump);
            if (randomJump <= 0.4f)
            {
                anim.Play("Armature_Jump-quick", -1);
            } else {
                anim.Play("Armature_Jump-flip", -1);
            }
        }
	}
}
