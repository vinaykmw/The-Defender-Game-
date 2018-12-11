using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCostScript : MonoBehaviour {
	public float goldCost=500f;
	public GameObject coins;
	public Transform[]  coinsThreower= new Transform[4];
	Image goldbar;
	public bool goldUnderAttack;
	public float radius;
	// Use this for initialization
	void Start () {
		goldbar = GameObject.Find ("gold bar").GetComponent<Image>();
		goldUnderAttack = false;
	}

	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere(transform.position, radius);
		//Gizmos.DrawSphere (transform.position, radius);
	}
	// Update is called once per frame
	void Update () {
		goldbar.fillAmount = goldCost / 500f;
		Collider[] colliders = Physics.OverlapSphere (transform.position, radius);
		foreach (Collider objects in colliders) {
			if (objects.CompareTag ("Terrorist")&&objects.GetComponent<Zombie_Follower>().IsAlive) {
				{
					goldUnderAttack = true;
					break;
				}
			}
		}


	}
	public	void instantiate_gold()
	{	
		for(int i=0;i<3; i++)
		{	for (int j = 0; j < 4; j++) {
				{	GameObject tempCoin = Instantiate (coins, coinsThreower [j].position, coinsThreower [j].rotation);
					
					Destroy (tempCoin, 15f);}

			}
			

		}
	}


	void OnTriggerExit(Collider other)
	{
		goldUnderAttack = false;
	}


}
