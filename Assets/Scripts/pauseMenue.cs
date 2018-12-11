using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenue : MonoBehaviour {
	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject maincanvas;
	Canvas a;
	private AudioSource[] allAudioSource;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StopAllAudio()
	{	Debug.Log ("stoping audio ");
		allAudioSource = FindObjectsOfType (typeof(AudioSource)) as AudioSource[];
		foreach(AudioSource source in allAudioSource)
		{	source.volume = 0f;
			source.Pause();

		}
	}
	public void playAllAudio()
	{	Debug.Log ("playing Audio");
		allAudioSource = FindObjectsOfType (typeof(AudioSource)) as AudioSource[];
		foreach(AudioSource source in allAudioSource)
		{	
			source.UnPause();
			source.volume = 1f;
		}
	}

	public void Resume()
	{	Debug.Log ("Audio resumed");
		if (GameIsPaused) {
			Time.timeScale = 1f;
			pauseMenuUI.SetActive (false);
			maincanvas.GetComponent<Canvas> ().enabled = true;
			playAllAudio ();
		}
	}

	public void pause()
	{
		pauseMenuUI.SetActive (true);
		maincanvas.GetComponent<Canvas> ().enabled = false;
		Time.timeScale = 0f;
		StopAllAudio ();
		GameIsPaused = true;


	}
	public void home()
	{
		//SceneManager.LoadScene (0);
		Time.timeScale = 1f;
	}
	public void quit()
	{
		Application.Quit();
	}


}
