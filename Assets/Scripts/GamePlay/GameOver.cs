using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	public int bestScore;
	public Sprite bronze; //10
	public Sprite silver; //20
	public Sprite gold; //30;
	public Sprite none;
	[SerializeField]
	private Canvas gameOver;
	[SerializeField]
	private Text sc;
	[SerializeField]
	private Text bSc;
	[SerializeField]
	private Button play;
	[SerializeField]
	private Button highscore;
	[SerializeField]
	private Image medalImage;
	// Use this for initialization
	void Start () {
		bestScore = PlayerPrefs.GetInt("High Score");
		bSc.text = "" + bestScore;
		gameOver.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Bird.instance.start) {
			if (Bird.instance.alive) {
				gameOver.gameObject.SetActive (false);
			} else {
				gameOver.gameObject.SetActive (true);
			}
		}
		sc.text = "" + Score.instance.score;
		if (Score.instance.score > PlayerPrefs.GetInt("High Score")) {
			bestScore = Score.instance.score;
			bSc.text = "" + bestScore;
			PlayerPrefs.SetInt ("High Score", bestScore);
		}
		checkMedal ();
	}

	public void Replay() {
		SceneManager.LoadScene ("FlappyBird");

	}

	void checkMedal () {
		if (Score.instance.score > 30) {
			medalImage.sprite = gold;
		} else if (Score.instance.score > 20) {
			medalImage.sprite = silver;
		} else if (Score.instance.score > 10) {
			medalImage.sprite = bronze;
		} else {
			medalImage.sprite = none;
		}
	}
}
