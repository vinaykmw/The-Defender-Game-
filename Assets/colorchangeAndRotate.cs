using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorchangeAndRotate : MonoBehaviour {
	float i;
	float r;
	Image stamp;
	// Use this for initialization
	void Start () {
		stamp = this.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		i+=.01f;
		r++;
		if (i >= 1)
			i = 0;
		this.transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, r));
		Color a;
		a = Color.HSVToRGB (i, 1, 1);
		stamp.color = a;
	}
}
