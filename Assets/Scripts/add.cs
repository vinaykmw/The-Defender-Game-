using UnityEngine;
using UnityEngine.Advertisements;

public class add : MonoBehaviour
{
	void Start()
	{
		
	}


	public void showAdd()
	{
		Debug.Log ("add requested");
		if (Advertisement.IsReady ("video")) {
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show ("video");
			//Time.timeScale = 0;

		}


	
	}



	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{	Time.timeScale = 0;
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)



		{
		case ShowResult.Finished:
			Debug.Log ("The ad was successfully shown.");
			Time.timeScale = 1;
			//
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			Time.timeScale = 1;
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			Time.timeScale = 1;
			break;
		}
	}
}