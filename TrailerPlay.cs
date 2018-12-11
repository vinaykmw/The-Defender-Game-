using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrailerPlay : MonoBehaviour {

	// Use this for initialization


	public GameObject button;
	void Start () {

		StartCoroutine (buttonactive ());

	}

	
	// Update is called once per frame



	IEnumerator buttonactive()
	{
		yield return new WaitForSeconds (3);
		button.SetActive (true);
		yield return new WaitForSeconds (18);


	}

}
