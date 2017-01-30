using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public void PlayButton () {
		SceneManager.LoadScene ("FlappyBird");
	}

	public void RateButton () {
		if (Application.platform == RuntimePlatform.Android) {
			//Application.OpenURL ("https://www.youtube.com");
			Debug.Log ("Rate my game in Play Store");
		} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
			Debug.Log ("Rate my game in AppStore");
		} else {
			//Application.OpenURL ("https://www.youtube.com");
			Debug.Log ("This is " + Application.platform);
		}
	}
}
