using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour {

	public GameObject player;
	Transform playerPos;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		playerPos = player.GetComponent<Transform> ();
		offset = -playerPos.position + transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//offset = playerPos.position - transform.position;
		transform.position = Vector3.Lerp( transform.position,offset+ playerPos.position,6f*Time.deltaTime);


	}


}
