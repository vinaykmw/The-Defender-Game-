using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupsInlevel2 : MonoBehaviour {
	public bool book;
	public bool school;
	// Use this for initialization
	void Start () {
		book = false;
		school = false;
	}
	
	public void takebook()
	{
		book = true;
	}
	public void goSchool()
	{
		school = true;
	}

}
