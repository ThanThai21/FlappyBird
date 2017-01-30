using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	void Awake () {
	}
	// Use this for initialization
	void Start () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		Vector3 tempScale = transform.localScale;
		float h = sr.bounds.size.y;
		float w = sr.bounds.size.x;
		float height = Camera.main.orthographicSize*2.3f;
		float with = height * Screen.width / Screen.height;
		tempScale.y = 128* height / h;
		tempScale.x = 128* with / w;
		transform.localScale = tempScale;	
	}
}
