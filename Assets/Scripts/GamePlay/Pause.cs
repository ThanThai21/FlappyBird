using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
	public bool isPause;
	[SerializeField]
	private Button pauseBtn; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isPause) {
			SceneManager.LoadScene ("Menu");			
		}
	}

	public void PauseGame () {
		isPause = true;
	}
}
