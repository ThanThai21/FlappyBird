using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {
	SpriteRenderer sr;
	float startTime;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		Color32 tempColor = sr.color;
		tempColor.a = 1;
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime < 1.5) {
			Color32 tempColor = sr.color;
			tempColor.a += 2;
			sr.color = tempColor;
		} else {
			Color32 tempColor = sr.color;
			tempColor.a -= 1;
			sr.color = tempColor;
			if (sr.color.a == 0) {
				SceneManager.LoadScene ("Menu");
			}
		}
	}
}
