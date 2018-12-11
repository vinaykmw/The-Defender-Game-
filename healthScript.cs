using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthScript : MonoBehaviour {
	public GameObject slider;
	public float health = 200f;
	public GameObject audio_modi;
	GameObject modi;
	// Use this for initialization
	void Start () {
		modi = GameObject.FindGameObjectWithTag ("Player");
		StartCoroutine (bombAdder ());
	}
	
	// Update is called once per frame
	void Update () {
		slider.GetComponent<Slider> ().value = health;
		if(health <= 0)
		{	audio_modi.GetComponent<Audiomanager>().revive();
			StartCoroutine (waitForControls ());
		}
	}

	IEnumerator waitForControls()
	{		
			modi.GetComponent<walkScript> ().die ();
			yield return new WaitForSeconds (2);
			health = 200;

	}
	IEnumerator bombAdder()
	{	
		while (true) {
			//Debug.Log ("Bomb added");
			modi.GetComponent<walkScript> ().Add_bomb ();
			yield return new WaitForSeconds (30);
		}
	}
}
