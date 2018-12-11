using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using	UnityEngine.AI;

public class girl_mover : MonoBehaviour {
	Animator animator_Girl;
	NavMeshAgent girl;
	Transform modiLocation;
	public float thresholddistance;
	public float distance;
	// Use this for initialization
	void Start () {
		modiLocation = GameObject.FindGameObjectWithTag ("Player").transform;
		girl = GetComponent<NavMeshAgent> ();
		animator_Girl = GetComponent<Animator> ();

	}
	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere(transform.position,thresholddistance );
		//Gizmos.DrawSphere (transform.position, radius);
	}
	
	// Update is called once per frame
	void Update () {
		
		distance = Vector3.Magnitude (transform.position - modiLocation.position);

		if (distance <= (thresholddistance)) {
			// stay abd be happy
			animator_Girl.SetBool("follow",false);
			animator_Girl.SetBool("idle",true);
		} else {
			girl.SetDestination (modiLocation.position);
			animator_Girl.SetBool ("follow", true);
			animator_Girl.SetBool("idle",false);
		}
	}


}
