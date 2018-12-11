using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class levelLoader : MonoBehaviour {
	public Image  loadingImage; 
	public Canvas loadingCanvas;
	public Text percent;
	public Text percent1;
	public GameObject addManager;
	int whilecount;
	//GameObject AddShow;
	// Use this for initialization
	void Start () {
		//AddShow = GameObject.FindGameObjectWithTag ("Add");
		if (SceneManager.GetActiveScene ().buildIndex == 1 || SceneManager.GetActiveScene ().buildIndex == 2) {
			addManager.GetComponent<add> ().showAdd ();

		}
	}
	
	// Update is called once per frame
	public void LoadLevel(int sceneIndex)
	{	
		StartCoroutine (LoadInBackground (sceneIndex));
	}

	IEnumerator LoadInBackground(int sceneIndex)
	{	/*	if (SceneManager.GetActiveScene().buildIndex != 0&&sceneIndex==0) {
			
		}*/
		loadingCanvas.GetComponent<Canvas>().enabled =true;
		
		yield return new  WaitForSeconds (1f);

		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);

		while (operation.isDone==false) {
			//float percentage;
			whilecount++;
			//percentage = operation.progress / 0.9f;
			float progress=Mathf.Clamp01(operation.progress/.9f);
			percent.text = (100*progress).ToString ()+'%';
			percent1.text = whilecount.ToString ();
			//Debug.Log (progress);
			loadingImage.fillAmount = progress;
			yield return null;

		}
	}
}
