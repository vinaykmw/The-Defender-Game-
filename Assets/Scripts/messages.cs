using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class messages : MonoBehaviour {
	GameObject modi;
	GameObject gold;
	Text message_text;
	public bool bagPicked;
	public Text scoreshow;
	public int score;
	bool win; 
	bool  loose;
	public GameObject tSpawner;
	//public GameObject terroristBat;
	bool underAttack;
	bool cancall;
	public GameObject canvasWinPanel;
	public GameObject maincanvas;
	public GameObject shop_button;
	public GameObject Bag;
	public GameObject girl;
	public GameObject Hut;

	// Use this for initialization
	void Start () {
		bagPicked = false;
		message_text = GetComponent<Text> ();
		modi = GameObject.FindGameObjectWithTag ("Player");
		gold = GameObject.FindGameObjectWithTag ("Gold");
		cancall = true;
		win = false;
		loose = false;
		score = modi.GetComponent<walkScript> ().zombieKilled;


	}

	// Update is called once per frame
	void Update () {
		score = modi.GetComponent<walkScript> ().zombieKilled;
		if (score >= 50&& loose == false) {
			Destroy (tSpawner);
			win = true;
			StartCoroutine(setText(" You Win"));

		}
		else if (gold.GetComponent<GoldCostScript> ().goldCost <= 0&& win==false) {
			StartCoroutine(setText(" You Loose "));
			loose = true;
		}
		if (GameObject.FindGameObjectWithTag ("Gold").GetComponent<GoldCostScript> ().goldUnderAttack&&cancall&&win == false && loose == false) {
			
			StartCoroutine(setText("Gold Under Attack"));
			underAttack = GameObject.FindGameObjectWithTag ("Gold").GetComponent<GoldCostScript> ().goldUnderAttack= false;
			cancall = false;
		}
		scoreshow.GetComponent<Text>().text = "Score " + score.ToString ();

		if (bagPicked) {
			
			bagPicked = false;
			shop_button.GetComponent<Text> ().text = "Take her to School";
		}
	}



	IEnumerator setText(string a)
	{	//yield return new WaitForSeconds (.1f);
		message_text.text = a.ToString();
		yield return new WaitForSeconds (4f);
		if (win) {
			Time.timeScale = 0;
			canvasWinPanel.SetActive (true);
			maincanvas.GetComponent<Canvas> ().enabled = false;
			//GameObject.FindGameObjectWithTag ("Add").GetComponent<add> ().ShowRewardedAd ();
			//GameObject.FindGameObjectWithTag ("Add").GetComponent<add> ().showAdd ();

		}
		if (loose) {
			Time.timeScale = 0;
			canvasWinPanel.SetActive (true);
			maincanvas.GetComponent<Canvas> ().enabled = false;

		}
			
		
		message_text.text = null;
		cancall = true;


	}

	public void pickbag()
	{
		bagPicked = true;
		Bag.SetActive (true);
		setText (" You Picked Bag ");
		girl.transform.LookAt (Hut.GetComponent<Transform>().position);

		girl.GetComponent<Animator> ().SetTrigger ("pickup");
		//girl.GetComponent<Animator> ().Play ("Swing Dancing");

	}
}
