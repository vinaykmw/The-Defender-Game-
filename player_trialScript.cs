using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class player_trialScript : MonoBehaviour {
	public VideoClip[] clips;
	VideoPlayer player;
	int currentClipNo= 0 ;

	void Start () {
		player = GetComponent<VideoPlayer> ();
		player.clip = clips [0];
		player.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{	
				changeVideo();
			}
		if(Input.GetKeyDown(KeyCode.Space)){
			if (player.isPlaying) {
				player.Pause ();
			} else
				player.Play ();
			
		}
	}

	void changeVideo()
	{	if (currentClipNo >= clips.Length-1) {
			currentClipNo = 0;
		}
		else currentClipNo = currentClipNo + 1;

		player.clip = clips [currentClipNo];
		player.Play ();

	}
}
