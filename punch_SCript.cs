using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punch_SCript : MonoBehaviour {
	public GameObject playerRef;
	public bool isAttacking;

	void Start()
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		isAttacking = playerRef.GetComponent<walkScript> ().isPunching;
		//Debug.Log("Collision occured");

		if(other.gameObject.CompareTag("Terrorist")&&isAttacking&&other.gameObject.GetComponent<Zombie_Follower>().IsAlive)
		{
			//Debug.Log("terrorist got hit by punch");
			other.gameObject.GetComponent<Zombie_Follower> ().ZombieHelth = other.gameObject.GetComponent<Zombie_Follower> ().ZombieHelth - 35;

			other.gameObject.transform.LookAt (playerRef.transform);
			other.gameObject.GetComponent<Zombie_Follower> ().GetPunched ();
		}

	}
}
