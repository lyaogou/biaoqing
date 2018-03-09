/*1030514411 夏文利*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero_anima : MonoBehaviour {
	[HideInInspector]
	public bool facingRight = true;//判断角色是不是面xiang右bian
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 365f;
	private bool grounded = false;
	[HideInInspector]
	public bool jump = false;

	private Animator anima;
	private Rigidbody2D hero;
	private Transform groundCheck;

	// Use this for initialization
	void Start () {
		anima = GetComponent<Animator>();
		hero = GetComponent<Rigidbody2D> ();
		groundCheck = transform.Find ("groundCheck");
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast (transform.position, groundCheck.position,1 <<LayerMask.NameToLayer("ground"));
		if (Input.GetButtonDown ("Jump") && grounded) {
			jump = true;
//			anima.SetTrigger ("jump");
		}
	}
	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		anima.SetFloat ("speed", Mathf.Abs (h));
		//zhuan身功能
		if (h > 0 && !facingRight) {
			Flip ();
		} else if (h < 0 && facingRight) {
			Flip ();
		}
		//行走功能
		if (h * hero.velocity.x < maxSpeed) {
			hero.AddForce (Vector2.right*h*moveForce);
		}
		if (Mathf.Abs(hero.velocity.x) > maxSpeed) {
			hero.velocity = new Vector2 (Mathf.Sign(hero.velocity.x)*maxSpeed, hero.velocity.y);
		}
		//起跳
		if(jump){
			hero.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}

	}

	void Flip(){
		//zhuan身功能
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x = -1*theScale.x;
		transform.localScale = theScale;
	}
}
