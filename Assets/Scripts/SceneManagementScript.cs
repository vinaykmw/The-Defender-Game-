using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour {

	// Use this for initialization
	public GameObject canvasHome;
	public GameObject canvasLevel;
	
	// Update is called once per frame
	public void home(){
		SceneManager.LoadScene (0);
	}
	public void AR_MODE(){
		SceneManager.LoadScene(1);

	}
	public void non_AR()
	{
		SceneManager.LoadScene (2);
	}
	public void quit()
	{
		Application.Quit ();
	}
	public void homecanvas ()
	{
		canvasHome.GetComponent<Canvas> ().enabled = true;
		canvasLevel.GetComponent<Canvas> ().enabled = false;
	}
	public void levelCanvas()
	{
		canvasHome.GetComponent<Canvas> ().enabled = false;
		canvasLevel.GetComponent<Canvas> ().enabled = true;
	}
	public void loevel1()
	{
		SceneManager.LoadScene (1);
	}
	public void loevel2()
	{
		SceneManager.LoadScene (2);
	}
}
