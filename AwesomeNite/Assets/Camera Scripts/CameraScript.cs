using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public float followHeight = 8f;
    public float followDistance = 6f;
    public GameObject playerGO;

    private Transform player;

    private float targetHeight;
    private float currentHeight;
    private float currentRotation;

    // Use this for initialization
    private void Awake()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        //this.player = this.playerGO.transform; ONLY IF USING GameObject Edition
    }
    private void OnEnable()
    {
        
    }
    void Start () {
	
	}
	// Update is called once per frame
	void Update () {
        this.targetHeight = this.player.position.y + this.followHeight;
        this.currentRotation = this.transform.eulerAngles.y;
        this.currentHeight = Mathf.Lerp(this.transform.position.y, this.targetHeight, 0.9f * Time.deltaTime);
        Quaternion euler = Quaternion.Euler(0f, this.currentRotation, 0f);
        Vector3 targetPosition = this.player.position - (euler * Vector3.forward) * this.followDistance;

        targetPosition.y = this.currentHeight;

        this.transform.position = targetPosition;
        this.transform.LookAt(this.player);
    }
}
