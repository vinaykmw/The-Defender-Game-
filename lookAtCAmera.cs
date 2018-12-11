using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class lookAtCAmera : MonoBehaviour {
	public Transform mainCamera;
	public Transform modi;
	public float distance;
	// Use this for initialization

	void Start () {
		//nav = GetComponent<NavMeshAgent> ();

	}

	// Update is called once per frame
	void Update () {
		/*Cdistance = (transform.position - modi.position).magnitude;
		if (Cdistance> distance) {
			Debug.Log("destinatio nset");

			//transform.LookAt (mainCamera);
		}*/
		 distance = Vector3.Magnitude (transform.position - modi.position);
		if (.7<distance/*&& distance<200*/) {
			transform.LookAt (modi);

		}
		
	}
}
