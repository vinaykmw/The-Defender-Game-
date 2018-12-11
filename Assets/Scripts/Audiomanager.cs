using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour {

	public AudioClip []  files= new AudioClip[5];
	AudioSource source;
	int i=0;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		StartCoroutine (playingclips ());
	
	}


/*	void Update () {
		
		if (!source.isPlaying) {
			changeAudio (i);
			i++;
			if (i >= 4) {
				i = 0;	}
		}
	}*/

	IEnumerator playingclips()
	{
		while (true) {
		
		source.clip = files [i];
			source.Play ();
			yield return new WaitForSeconds (source.clip.length);
			i++;
			if (i >= 3)
				i = 0;
			

		}
	}

	/*void changeAudio(int a)
	{	if (!source.clip.Equals (files [a])) {
			source.clip = files [a];
			source.Play ();	}
		
		
	}*/

	public void revive()
	{	
		
		Debug.Log ("reviving");
		source.Pause();
		source.clip = files [4];
		source.Play ();

	}
}
