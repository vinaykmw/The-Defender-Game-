using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class colorChangerScript : MonoBehaviour {

	public float h,s,v;	
	Color _alpha;
	Button sourceButton;
	Color newColor;
	float alphavalue;
	 

	// Use th for initialization
	void Start () {
		sourceButton = this.GetComponent<Button> ();
		s = 60 / 100;;
		v = 90/100;
		alphavalue = .01f;
	}
	


	void Update () {
		StartCoroutine (changeColor ());
		ColorBlock cb = sourceButton.colors;
		newColor = Color.HSVToRGB (h, s, v);
		newColor.a = alphavalue;
		//cb.normalColor = newColor;

		_alpha.a = alphavalue;
		cb.normalColor = newColor;
		alphavalue += .02f;
		if (alphavalue >= .8f)
			alphavalue = 0.03f;
		sourceButton.colors = cb;
	}




	IEnumerator changeColor()
	{
		yield return new WaitForSeconds (.1f);
		h= h+.01f;
		s=s+.05f;
		v+=.05f;
		if (h >= 1) {
			h=0;
		}
		if (s >= 1) {
			s=.80f;
		}
			
		if (v >= 1) {
			v=.90f;
		}
	}
}
