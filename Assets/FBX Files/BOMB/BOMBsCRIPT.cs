using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOMBsCRIPT : MonoBehaviour {
	AudioSource source;
	public AudioClip[] file = new AudioClip[2]; 
	public GameObject explosion;
	bool explode_state = true;
	//public GameObject fumes;
	public float radius;
	public float  power;
	public float upforce;
	public GameObject bomb_mesh;
	public GameObject bomb_cylender;
	// Use this for initialization
	void Start () {
		//StartCoroutine (explode ());
		source = GetComponent<AudioSource>();
		//explosion.SetActive = false;
		//fumes.SetActive = true;
		source.clip = file [0];
	}
	
	// Update is called once per frame
	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere(transform.position, radius);
		//Gizmos.DrawSphere (transform.position, radius);
	}
	void Update () {
		
	}
	void detonate()
	{	if (explode_state ==true) {
			Vector3 explosionPosition = this.transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosionPosition, radius);
			foreach (Collider objects in colliders) {
				Rigidbody rb = objects.GetComponent<Rigidbody> ();
				if (rb != null) {
					rb.AddExplosionForce (power, explosionPosition, radius, upforce, ForceMode.Impulse);
				}
				if (objects.CompareTag ("Terrorist")) {
					float damage_radius;
					damage_radius = Vector3.Magnitude (objects.transform.position - this.transform.position) / radius;
					float damage = 50f + 100f * (1 / (damage_radius + .01f));
					objects.gameObject.GetComponent<Zombie_Follower> ().ZombieHelth = objects.gameObject.GetComponent<Zombie_Follower> ().ZombieHelth - damage;
					Debug.Log ("BOMB damage Given");
				}
			}
			source.clip = file [0];
			Instantiate (explosion, this.gameObject.transform);
			source.Play ();
			explode_state = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		
		//Debug.Log("Collision occured");
		if(other.gameObject.CompareTag("Terrorist")&&other.gameObject.GetComponent<Zombie_Follower>().IsAlive)
		{
			//Debug.Log("terrorist got hit by kick");
			StartCoroutine (explode ());


			//other.gameObject.transform.LookAt (playerRef.GetComponent<Transform>());
		}

	}
	IEnumerator explode()
	{	//Debug.Log ("a");
		yield return new WaitForSeconds (2f);
		detonate ();
		bomb_mesh.GetComponent<MeshRenderer> ().enabled = false;
		bomb_cylender.GetComponent<MeshRenderer> ().enabled = false;
		yield return new WaitForSeconds (4f);
		Destroy (this.gameObject);
		//Debug.Log ("b");
	}
}