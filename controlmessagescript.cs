using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlmessagescript : MonoBehaviour {
	public string[] texts;
	public Text controltext;
	int i;
	// Use this for initialization
	void Start () {
		StartCoroutine (controlMessage ());
	}
	
	// Update is called once per frame
	IEnumerator controlMessage()
	{
		while (true) {
			yield return new WaitForSeconds (5);
			controltext.text = texts [i];
			yield return new WaitForSeconds (5);
			i++;
			controltext.text = null;
			if (i >= texts.Length) {
				i = 0;
				yield return new WaitForSeconds (20);
			}
				
		}
	}
}
