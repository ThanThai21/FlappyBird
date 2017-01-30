using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour {
	public static Tab instance;
	[SerializeField]
	public Button startBtn;
	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void StartButton () {
		if (Bird.instance.start == false) {
			Bird.instance.start = true;
			Bird.instance.alive = true;
			startBtn.gameObject.SetActive (false);
		} 
	}
}
