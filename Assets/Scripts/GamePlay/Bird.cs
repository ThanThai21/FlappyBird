using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public static Bird instance;
	public float speed = 0.03f;
	public int force;
	private Rigidbody2D bird;
	private Animator anim;
	public AudioSource audioSource = null;
	private bool audioplay = false;
	private bool audiodieplay = false;
	public AudioClip flapping,ping,died;
	private float angle;
	public bool alive;
	public bool start;
	void Awake() {
		start = false;
		bird = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		MakeInstance ();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (start) { 
			bird.simulated = true;
			if (alive) {
				Flap ();
			} else {
				Die ();
			}
		} else {
			bird.simulated = false;
		}
	}

	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}

	void Flap () {
		if (Input.touchCount > 0 || Input.GetKey(KeyCode.Space)) {
			angle = 30;
			if (bird.position.y < 4.5) {
				bird.velocity = new Vector2 (bird.velocity.x, force);
			} else {
				bird.velocity = new Vector2 (bird.velocity.x, 0);
			}
			Fly (angle);
		} else {
			angle -= 1;
			Fall (angle);
		}
	}

	void Fly (float angle) {
		bird.MoveRotation (angle);
		if (!audioplay) {
			audioSource.PlayOneShot (flapping);
			audioplay = true;
		}
	}

	void Fall (float angle) {
		bird.MoveRotation (angle);
		audioplay = false;
	}

	void Die () {
		bird.velocity = new Vector2 (0, 1);
		bird.velocity = new Vector2 (0, -10);
		while (bird.rotation > -90) {
			bird.rotation -= 5;
		}
		if (!audiodieplay) {
			audioSource.PlayOneShot (died);
			audiodieplay = true;
		}
	}

	void OnCollisionEnter2D (Collision2D target) {
		if (target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground") {
			alive = false;
			anim.SetTrigger ("died");
		}
	}
}
