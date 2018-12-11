using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class focus_camera : MonoBehaviour {
/*	public Transform modi;
	Vector3 offset;


	// Use this for initialization
	void Start () {
		offset = transform.position - modi.position;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.LookAt (modi);
		transform.position = Vector3.Lerp(transform.position, modi.position + offset,5f*Time.deltaTime);
	}
}


*/
 	public Transform modi;
	Vector3 offset;
	//public Transform terrorist;
	//public Vector3 average;


	// Use this for initialization
	void Start () {
		//average = (terrorist.position + modi.position)*.05f;
		offset = transform.position - modi.position;//average;
	}
	
	// Update is called once per frame
	void Update () {
		//average = (terrorist.position + modi.position)*.05f;
		transform.position = Vector3.Lerp(transform.position,/* average + */offset+modi.position,6f*Time.deltaTime);
	}
}
 