using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScript : MonoBehaviour {
    private Animator anim;
    private bool isWalking = false;

	// Use this for initialization
	void Awake () {
        this.anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(this.isWalking)
            {
                if (this.anim.GetFloat("Run") == 0f)
                {
                    this.anim.SetFloat("Run", 1f);

                }
                else {
                    this.anim.SetFloat("Run", 0f);
                }
            }
        }
	}
}
