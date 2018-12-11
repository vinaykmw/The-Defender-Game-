using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperPart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.rotation = Quaternion.Euler (new Vector3 (Random.Range (0, 360), Random.Range (0, 360), Random.Range (0, 360)));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
