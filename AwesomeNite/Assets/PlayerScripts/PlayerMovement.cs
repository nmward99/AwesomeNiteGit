using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private CharacterController charController;
    private CollisionFlags collisionFlags;

    private float moveSpeed = 5f;
    private bool canMove;
    private bool finishedMovement = true;

    private Vector3 targetPos = Vector3.zero;
    private Vector3 playerMove = Vector3.zero;

    private float playerToPointDistance;

    private float gravity = 9.8f;
    private float height;
    
	// Use this for initialization
	void Awake ()
    {
        this.anim = this.GetComponent<Animator>();
        this.charController = this.GetComponent<CharacterController>();
        this.collisionFlags = this.charController.collisionFlags;
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.calculateHeight();
        this.checkIfFinishedMovement();
    }
    void calculateHeight() {
        if(isGrounded()) {
            height = 0f;
        }
        else {
            this.height -= this.gravity * Time.deltaTime;
        }
    }
    void checkIfFinishedMovement()
    {
        if (!this.finishedMovement)
        {
            if (!this.anim.IsInTransition(0) && !this.anim.GetCurrentAnimatorStateInfo(0).IsName("Stand") && this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                finishedMovement = true;
            }
        }
        else
        {
            MoveThePlayer();
            this.playerMove.y = this.height * Time.deltaTime;
            this.collisionFlags = this.charController.Move(this.playerMove);
        }
        
    }
    bool isGrounded()
    {
        return this.collisionFlags == CollisionFlags.Below ? true : false;
    }
    void MoveThePlayer()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider is TerrainCollider)
                {
                    this.playerToPointDistance = Vector3.Distance(this.transform.position, hit.point);
                    if(this.playerToPointDistance >= 1.0f)
                    {
                        this.targetPos = hit.point;
                        this.canMove = true;
                    }
                }
            }
            
        }
        if (this.canMove)
        {
            this.anim.SetFloat("Walk", 1.0f);
            Vector3 targetTemp = new Vector3(this.targetPos.x, this.transform.position.y, this.targetPos.z);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                    Quaternion.LookRotation(targetTemp - this.transform.position), 15.0f - Time.deltaTime);
            this.playerMove = this.transform.forward * this.moveSpeed * Time.deltaTime;

            if (Vector3.Distance(targetPos, this.transform.position) <= 0.5f)
            {
                this.canMove = false;
            }
        }
        else
        {
            this.playerMove.Set(0f, 0f, 0f);
            this.anim.SetFloat("Walk", 0f);
        }
    }
    
}
    
