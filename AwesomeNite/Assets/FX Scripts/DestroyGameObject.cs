using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour {
    public float timeToWait = 0.1f;
    IEnumerator KillMyself()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
    // Use this for initialization
    void Start () {
        StartCoroutine(KillMyself());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
