using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie_Follower : MonoBehaviour {
	CapsuleCollider Tcollider;
	Transform Modi_location;
	Transform Gold_location;
	GameObject player;
	public float ZombieHelth = 100;
	public float Distance_threshold;
    NavMeshAgent nav;
	Animator animT;

	public float Distance;
	public float goldDistance;
	public bool IsAlive = true;
	public bool h_v=false;
	public bool canGiveDAmage;
	public float sdPlayer= 2.1f;
	public float sdGold = 3.78f;
	Transform targetLook ;
	public AudioClip []  filesZ= new AudioClip[8];
	AudioSource source;
	bool you_win;
	public float lookuprange;
	// Use this for initialization
	void Start () {
		
		you_win = false;
		animT = GetComponent<Animator> ();
		Gold_location = GameObject.FindGameObjectWithTag ("Gold").transform;
		Modi_location = GameObject.FindGameObjectWithTag ("Player").transform;
		player=GameObject.FindGameObjectWithTag("Player");
		source = GetComponent<AudioSource> ();
		source.clip = filesZ [Random.Range (6, 8)];
		source.Play ();
		ZombieHelth = 100;
		nav = GetComponent<NavMeshAgent> ();
		Tcollider = GetComponent<CapsuleCollider> ();

	}
	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere(transform.position, lookuprange);
		//Gizmos.DrawSphere (transform.position, radius);
	}
	
	// Update is called once per frame
	void Update () {
		
		 goldDistance = Vector3.Magnitude (transform.position - Gold_location.position);
		 Distance = Vector3.Magnitude (transform.position - Modi_location.position);
	//	Gizmos.DrawSphere (transform.position, Distance_threshold);
		if (Distance < lookuprange) {
			if (Distance <= Distance_threshold && IsAlive && (goldDistance >= sdGold) && (goldDistance < Distance)) {
				//Debug.Log ("Following");
				nav.enabled = true;
				nav.SetDestination (Gold_location.position);
				animT.SetBool ("Walking", true);
				animT.SetBool ("Idle", false);
				targetLook = Gold_location;
				nav.stoppingDistance = sdGold;
			} else if (Distance <= Distance_threshold && IsAlive && (Distance >= sdPlayer) && (goldDistance > Distance)) {
				//Debug.Log ("Following");
				nav.enabled = true;
				nav.SetDestination (Modi_location.position);
				animT.SetBool ("Walking", true);
				animT.SetBool ("Idle", false);
				targetLook = Modi_location;
				nav.stoppingDistance = sdPlayer;
			} else {
		
				//nav.enabled = false;
				animT.SetBool ("Walking", false);
				animT.SetBool ("Idle", true);
				Hit (targetLook);

			}

			if (ZombieHelth <= 0 && IsAlive) { //// when dead
				//	Debug.Log("dead in loop");
				nav.enabled = false;
				Tcollider.height = .5f;
				Tcollider.radius = .5f;
				animT.SetTrigger ("IsDead");
				source.clip = filesZ [3];
				source.Play ();
				IsAlive = false;
				player.GetComponent<walkScript> ().scoreAdder ();

			}
		}
		else 
		{
			animT.SetBool ("Idle", true);
			animT.SetBool ("Walking", false);
				
			}
	}
	public void Hit(Transform targetlook )
	{	
		//Debug.Log ("hit called");
		if (IsAlive) {
			transform.LookAt (targetlook);				
			if (h_v == false) {
				animT.SetTrigger ("AttackH");
				h_v =true;


			} else {
				animT.SetTrigger ("AttackV");
				h_v = false;
			}
		}
	}

	public	void GetPunched()
	{
		if (IsAlive) {

			animT.Play ("Taking_Punch");
			source.clip = filesZ [4];
			source.Play ();
		}

	}
	public	void GetKick()
	{
		if (IsAlive) {
			{
				animT.Play ("Get_hit");
				source.clip = filesZ [5];
				source.Play ();
			}

		}
	}

	public void Destroy_Terrorist()
	{	
		//Debug.Log ("destroying gamepbjet");
		Destroy (this.gameObject,5f);
	}
	public void giveDamage()
	{	
		canGiveDAmage = true;
		int a =Random.Range (1, 3);
		source.clip = filesZ [a];
		source.Play ();
		//Debug.Log ("Can give damage");
	}
	public void NotgiveDamage()
	{	//Debug.Log ("not give damage");
		canGiveDAmage = false;
	}




}
