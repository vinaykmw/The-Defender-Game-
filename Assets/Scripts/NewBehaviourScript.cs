using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	Rigidbody rb1;
	// Use this for initialization
	void Start () {
		rb1 = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		rb1.velocity = new Vector3 (x, 0, y) * 5f;
	}
}
