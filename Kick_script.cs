using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick_script : MonoBehaviour {

	public GameObject playerRef;
	public bool isAttacking;
	void Start()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		isAttacking = playerRef.GetComponent<walkScript> ().isKicking;
		//Debug.Log("Collision occured");
		if(other.gameObject.CompareTag("Terrorist")&&isAttacking)
		{
			//Debug.Log("terrorist got hit by kick");
			other.gameObject.GetComponent<Zombie_Follower> ().ZombieHelth = other.gameObject.GetComponent<Zombie_Follower> ().ZombieHelth - 45;

			other.gameObject.GetComponent<Zombie_Follower> ().GetKick ();
			//other.gameObject.transform.LookAt (playerRef.GetComponent<Transform>());
		}

	}
}
