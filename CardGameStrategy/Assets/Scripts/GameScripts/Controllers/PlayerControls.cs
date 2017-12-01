using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") != 0)
        {
            this.transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical")*speed*Time.deltaTime));
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            this.transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0));
        }
	}
}
