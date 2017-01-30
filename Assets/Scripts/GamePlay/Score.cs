using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public static Score instance;
	public int score = 0;
	[SerializeField]
	private Text text;

	void Awake () {
		if (instance == null) {
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "" + score; 
		if (Bird.instance.alive == false) {
			text.gameObject.SetActive (false);
		} else {
			text.gameObject.SetActive (true);
		}
	}


}
