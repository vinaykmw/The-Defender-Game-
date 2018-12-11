using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniCameraScript : MonoBehaviour {
	Transform modi;
	Vector3 pos;
	// Use this for initialization
	void Start () {
		modi = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
		pos = new Vector3 (modi.position.x, this.transform.position.y, modi.position.z);
		transform.position = pos;
	}
}
