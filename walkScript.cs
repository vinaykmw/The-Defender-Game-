using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class walkScript : MonoBehaviour {
	public bool Grounded;
	//Rigidbody rb;
	public GameObject wall;
	public Text bombCount;
	/// <summary>
	public Transform WAll_maker;
	/// </summary>
	public int zombieKilled;
	Transform player_transform;

	public Vector3 loaction;
	Animator anim;
	bool isHeAlive;
	public bool isAttacking;
	public bool isPunching;
	public bool isKicking;
	bool canPressButton;
	//Vector3 AttackRotation;
	public float rotateangle;
	Transform target;
	bool punchside=true;
	public AudioClip []filesModi = new AudioClip[4];
	AudioSource source;
	public bool controls_active;
	int bomb;


	void Start () {
		
		player_transform = GetComponentInParent<Transform> ();
		source = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		isAttacking = false;
		controls_active = true;
		zombieKilled = 0;
		bomb = 5;
		//GameObject.FindGameObjectWithTag ("Add").GetComponent<add> ().showAdd();

	}
	

	void Update () {
		
		if(controls_active){
		float x = CrossPlatformInputManager.GetAxis ("Horizontal");
		float y = CrossPlatformInputManager.GetAxis("Vertical");

			bombCount.text = bomb.ToString ();




		if (x != 0 || y != 0) {

			anim.SetBool ("Walking", true);
			anim.SetBool ("idle", false);

			player_transform.transform.rotation = Quaternion.Euler (new Vector3 (0f, Mathf.Atan2 (x, y + .0001f) * Mathf.Rad2Deg, 0f));
		} else {
			//anim.applyRootMotion = true;
			anim.SetBool ("idle", true);
			anim.SetBool ("Walking", false);
		}

		/*if (player_transform.position.y <= -1) {

		}*/
		loaction = player_transform.position;
		}
	}




	void OnTriggerEnter(Collider other)
	{
		//Debug.Log ("terrorist in range");
		if(other.gameObject.CompareTag("Terrorist"))
			{
			target = other.gameObject.transform;	
			isHeAlive = other.gameObject.GetComponent<Zombie_Follower> ().IsAlive;
			}

	}



	void OnTriggerStay(Collider other)
	{
		///Debug.Log ("terrorist in range");
		if(other.gameObject.CompareTag("Terrorist"))
		{
			target = other.gameObject.transform;
			isHeAlive = other.gameObject.GetComponent<Zombie_Follower> ().IsAlive;

		}
	}




	void OnTriggerExit(Collider other)
	{
		//Debug.Log ("terrorist in range");
		if(other.gameObject.CompareTag("Terrorist"))
		{	
			target = other.gameObject.transform;

		}
	}




	public void slash()
	{	isAttacking = true;
		anim.Play("Slash");
	}



	public void jump_attack()
	{	if (!isAttacking) {
			isAttacking = true;
			anim.SetTrigger ("jumpHit");
			source.clip = filesModi [0];
			source.Play ();
		}
	}



	public void punch()
	{	
		//rotateangle = Mathf.Atan2 (AttackRotation.z, AttackRotation.x)* Mathf.Rad2Deg ;
		if (!isPunching) {
			isPunching = true;
			//player_transform.transform.rotation = Quaternion.Euler (new Vector3 (0f,  Mathf.Atan2 (AttackRotation.z, AttackRotation.x) * Mathf.Rad2Deg  , 0f));
			if (isHeAlive)
				transform.LookAt (target);

			if (punchside) {
				anim.SetTrigger ("punch");
				punchside = false;
			} else {
				anim.SetTrigger ("punchL");
				punchside = true;
			}
		}
	
	}


	public void die()
	{	
		anim.Play("Dying");
	}



	public void kick()
	{	if (!isKicking) {
			isKicking = true;
			if (isHeAlive)
				transform.LookAt (target);
			anim.SetTrigger ("kick");
		}
	}

	public void make_wall()
	{	
		if(bomb>0){
			anim.applyRootMotion = false;	
			anim.SetTrigger ("wall");
			bomb--;

		}
	}

	public void NotAttacking()
	{
		isAttacking = false;
		isPunching = false;
		isKicking = false;
		//Debug.Log ("not Attacking ");
	}

	public void Instantiate_Wall()
	{	
		Instantiate (wall,WAll_maker.position,WAll_maker.rotation);
		Debug.Log ("made a wall");
	}

	public void  transformReset()
	{	Debug.Log ("RESET CALLED");
		//Vector3 temp;
	//	temp = transform.position;
		//this.transform.position = new Vector3 (this.transform.position.x, 0f, this.transform.position.z)*Time.deltaTime;
		transform.position = new Vector3 (loaction.x, 0f, loaction.z);
		transform.rotation = Quaternion.Euler (new Vector3 (0f, player_transform.rotation.y, 0f));
		anim.applyRootMotion = true;
	}
	public void Add_bomb()
	{
		if( bomb <=5)
		{bomb = bomb + 1;	
			//Debug.Log ("Bomb added")
			}
	}

	public void  scoreAdder()
	{
		zombieKilled = zombieKilled + 1;
	}

}





		


