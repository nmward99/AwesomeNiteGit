using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour {
    public Texture2D cursorTexture;
    //public GameObject mousePoint;
    private CursorMode mode = CursorMode.ForceSoftware;
    private Vector2 hotSpot = Vector2.zero;

    private GameObject mousePoint;
    private GameObject instantiatedMouse;

	// Use this for initialization
	void Start () {
		
	}

    
	// Update is called once per frame
	void Update () {
        Cursor.SetCursor(this.cursorTexture, this.hotSpot, this.mode);
        if (Input.GetMouseButtonUp(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            this.instantiatedMouse = GameObject.Instantiate(this.mousePoint);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider is TerrainCollider)
                {
                    Vector3 temp = hit.point;
                    temp.y = 0.35f;
                    //this.instantiatedMouse.transform.position = temp;
                    this.instantiatedMouse = Instantiate(this.mousePoint, temp, Quaternion.identity)
                    
;                }
            }
        }
    }
}
