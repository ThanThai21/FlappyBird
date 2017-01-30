using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour {
	public bool top;
	public static float random = 0;
	[SerializeField]
	private BoxCollider2D collide;

	void Awake () {
		collide = GetComponent<BoxCollider2D> ();
	}

	void Start () {
		if (top) {
			transform.localScale = new Vector3 (512, 640, 0);
		}
	}

	void FixedUpdate () {
		Move ();
	}

	void Move () {
		if (Bird.instance.alive) {
			if (top) {
				if (transform.position.x >= -4) {
					transform.position = new Vector2 (transform.position.x - Bird.instance.speed, transform.position.y);
					if (transform.position.x >= -1.26f && transform.position.x <= -1.26f + Bird.instance.speed) {
						Bird.instance.audioSource.PlayOneShot (Bird.instance.ping);
						Score.instance.score++;
					}
				} else {
					do {
						random = 0.4f * Random.Range (-5, 5);
					} while (transform.position.y - random > 7.8 || transform.position.y - random < 4.2);
					transform.position = new Vector2 (5.0f+(9/16)*(Screen.height/Screen.width), transform.position.y - random);
					if (Bird.instance.speed <= 0.08f) {
						Bird.instance.speed += 0.002f;
					}
				}
			} 
		}
	}

	void OnCollisionEnter2D (Collision2D target) {
		if (target.gameObject.tag == "Player") {
			collide.isTrigger = true;
		}
	}
}
