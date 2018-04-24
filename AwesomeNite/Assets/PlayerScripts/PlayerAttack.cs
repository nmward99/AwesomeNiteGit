using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {
    public Image fillWaitImage1_1;
    public Image fillWaitImage1_2;
    public Image fillWaitImage1_3;
    public Image fillWaitImage1_4;
    public Image fillWaitImage1_5;
    public Image fillWaitImage1_6;

    private int[] fadImages = new int[] { 0, 0, 0, 0, 0, 0 };
    private Animator anim;
    private bool canAttack = true;

    private PlayerMovement PlayerMove;

    // Use this for initialization
    void Awake () {
        this.anim = this.GetComponent<Animator>();
        this.PlayerMove = this.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update() {
        if (!this.anim.IsInTransition(0) && this.anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
        {
            canAttack = true;
        }
        else {
            canAttack = false;
        }
    
    }
}
