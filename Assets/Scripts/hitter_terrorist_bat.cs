using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitter_terrorist_bat : MonoBehaviour {
	public GameObject zombie;
	GameObject playrRef;
	GameObject goldReferance;

	// Use this for initialization
	void Start()
	{
		playrRef = GameObject.FindWithTag ("Player");
		goldReferance = GameObject.FindGameObjectWithTag ("Gold");

	}
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log ("something collided in range");
		//print (other.gameObject.name);
		if(other.gameObject.CompareTag("Cbody"))
		{	//Debug.Log ("HE got hit");
			if (zombie.GetComponentInParent<Zombie_Follower> ().canGiveDAmage) 
			{
				playrRef.GetComponentInParent<healthScript> ().health = playrRef.GetComponent<healthScript> ().health - 15f;
				//Debug.Log ("player got damage");
				//GetCom

			}
		}
		if(other.gameObject.CompareTag("Gold"))
		{	//Debug.Log ("trying stealing gold");
			if (zombie.GetComponentInParent<Zombie_Follower> ().canGiveDAmage) {
				
				goldReferance.GetComponent<GoldCostScript> ().goldCost = goldReferance.GetComponent<GoldCostScript> ().goldCost - 25f;
				goldReferance.GetComponent<GoldCostScript> ().instantiate_gold ();
				//Debug.Log ("stealing gold");
				//GetCom

			} 
		}

	}
	void OnCollisionStay(Collision other)
	{
		//Debug.Log ("sstay ");
	}
	void OnCollisionExit(Collision other)
	{	
		//Debug.Log ("exit");
	}

}
