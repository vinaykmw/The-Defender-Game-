using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class inGamePlayer : MonoBehaviour {
	public GameObject pickups;
	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject maincanvas;
	public GameObject exitpanal;
	public Text messageDislpay;
	Canvas a;
	VideoPlayer videoplayer;
	public VideoClip 	takeBook;
	public VideoClip	leaveSchool;
	VideoPlayer videoPlayer;
	//public RawImage screen;
	public GameObject RenderScren;
	//public MovieTexture trailer2;
	//public MovieTexture trailer3;
	public GameObject continueButton; 
	public GameObject EndmenueButton;
	//public MovieTexture trailer2;
	//AudioSource speaker;
	private AudioSource[] allAudioSource;
	private AudioSource videoSpeaker;
	// Use this for initialization
	void Start () {
		videoplayer = GetComponent<VideoPlayer> ();
		exitpanal.SetActive (false);
	//	speaker = GetComponent<AudioSource> ();
		EndmenueButton.SetActive (false);
		videoSpeaker = GetComponent<AudioSource> ();
		//videoPlayer.SetTargetAudioSource(0,videoSpeaker);
		//Playtrailer1 ();
	}

	// Update is called once per frame

	public void StopAllAudio()
	{	
		allAudioSource = FindObjectsOfType (typeof(AudioSource)) as AudioSource[];
		foreach(AudioSource source in allAudioSource)
		{	source.volume = 0f;
			source.Pause();
		}
	}

	public void playAllAudio()
	{	allAudioSource = FindObjectsOfType (typeof(AudioSource)) as AudioSource[];
		foreach(AudioSource source in allAudioSource)
		{	
			if (!source.isPlaying) {
				source.UnPause ();
				source.volume = 1f;
			}
		}
	}



		/*if (!speaker.isPlaying) {
			this.enabled = false;
			maincanvas.GetComponent<Canvas> ().enabled = true;
		}*/
	


	public void bookShop()
	{

			StopAllAudio ();
			//screen.GetComponent<RawImage> ().enabled =true;
			//screen.GetComponent<RawImage>().texture = trailer2 as MovieTexture;
			//speaker.clip = trailer2.audioClip;
			//this.GetComponent<VideoClip>()= takeBook;
			RenderScren.SetActive (true);
			maincanvas.GetComponent<Canvas> ().enabled = false;
			continueButton.SetActive (true);
			videoplayer.clip = takeBook;
			//screen.GetComponent<RawImage> ().enabled =true;
			GetComponent<AudioSource> ().volume = 1f;
			Debug.Log ("cilp 1");
			Time.timeScale = 0;
			videoplayer.Play ();
			pickups.GetComponent<pickupsInlevel2> ().book = true;

			//speaker.Play ();
			//speaker.volume = 1f;
	}


	public void reachedSchool()
	{	if (pickups.GetComponent<pickupsInlevel2> ().book == true) {
			StopAllAudio ();
			EndmenueButton.SetActive (true);
			videoSpeaker.Play ();
			videoSpeaker.volume = 1f;
			RenderScren.SetActive(true);
			//screen.GetComponent<RawImage> ().enabled =true;
			//screen.GetComponent<RawImage>().texture = trailer2 as MovieTexture;
			//screen.texture = trailer3 as MovieTexture;
			//speaker.clip = trailer3.audioClip;
			maincanvas.GetComponent<Canvas> ().enabled = false;
			Time.timeScale = 0;
			videoplayer.clip = leaveSchool;
			Debug.Log("cilp 2");
			videoplayer.Play ();
			//trailer3.Play ();
			//speaker.Play ();
			//speaker.volume = 1f;
		}
	else{
		//go back and take books
		StartCoroutine(displayMessages("Go Back and take Books"));
	}

	}

	public void skip()
	{
		Time.timeScale = 1f;
		playAllAudio ();
		//videoplayer.clip = null;
		videoplayer.Pause ();
		//speaker.Pause ();
		//trailer2.Pause ();
		//trailer3.Pause ();
		maincanvas.GetComponent<Canvas> ().enabled = true;
		//screen.GetComponent<RawImage> ().enabled =false;
		continueButton.SetActive ( false);
		RenderScren.SetActive(false);
	}

	public void end()
	{
		Time.timeScale = 0;
		StopAllAudio ();
		maincanvas.GetComponent<Canvas> ().enabled = false;
		exitpanal.SetActive (true);
		RenderScren.SetActive(false);
	}


	IEnumerator displayMessages(string a)
	{	
		messageDislpay.text = a;
			yield return new WaitForSeconds(5f);
		messageDislpay.text = null;

	}


}
























/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inGamePlayer : MonoBehaviour {
	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject maincanvas;
	public GameObject exitpanal;
	Canvas a;
	public RawImage screen;
	public MovieTexture trailer2;
	public MovieTexture trailer3;
	public GameObject continueButton; 
	public GameObject EndmenueButton;
	//public MovieTexture trailer2;
	AudioSource speaker;
	private AudioSource[] allAudioSource;
	// Use this for initialization
	void Start () {
		exitpanal.SetActive (false);
		speaker = GetComponent<AudioSource> ();
		EndmenueButton.SetActive (false);
		//Playtrailer1 ();
	}

	// Update is called once per frame

	public void StopAllAudio()
	{	
		allAudioSource = FindObjectsOfType (typeof(AudioSource)) as AudioSource[];
		foreach(AudioSource source in allAudioSource)
		{	source.volume = 0f;
			source.Pause();
		}
	}
	public void playAllAudio()
	{	allAudioSource = FindObjectsOfType (typeof(AudioSource)) as AudioSource[];
		foreach(AudioSource source in allAudioSource)
		{	source.volume = 1f;
			if(!source.isPlaying)
				source.Play();
		}
	}

	void Update()
	{
		if (!speaker.isPlaying) {
			this.enabled = false;
			maincanvas.GetComponent<Canvas> ().enabled = true;
		}
	}


	public void bookShop()
	{
		StopAllAudio ();
		screen.GetComponent<RawImage> ().enabled =true;
		screen.GetComponent<RawImage>().texture = trailer2 as MovieTexture;
		speaker.clip = trailer2.audioClip;
		maincanvas.GetComponent<Canvas> ().enabled = false;
		continueButton.SetActive (true);
		//screen.GetComponent<RawImage> ().enabled =true;
		Time.timeScale = 0;
		trailer2.Play ();

		speaker.Play ();
		speaker.volume = 1f;
	}

	public void reachedSchool()
	{	
		StopAllAudio ();
		EndmenueButton.SetActive (true);
		screen.GetComponent<RawImage> ().enabled =true;
		screen.GetComponent<RawImage>().texture = trailer2 as MovieTexture;
		screen.texture = trailer3 as MovieTexture;
		speaker.clip = trailer3.audioClip;
		maincanvas.GetComponent<Canvas> ().enabled = false;
		Time.timeScale = 0;
		trailer3.Play ();
		speaker.Play ();
		speaker.volume = 1f;
	}

	public void skip()
	{	Time.timeScale = 1f;
		playAllAudio ();
		speaker.Pause ();
		trailer2.Pause ();
		trailer3.Pause ();
		maincanvas.GetComponent<Canvas> ().enabled = true;
		screen.GetComponent<RawImage> ().enabled =false;
		continueButton.SetActive ( false);
	}
	public void end()
	{
		Time.timeScale = 0;
		StopAllAudio ();
		maincanvas.GetComponent<Canvas> ().enabled = false;
		exitpanal.SetActive (true);

	}





}
*/