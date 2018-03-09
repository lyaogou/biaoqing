/*1030514411 夏文利*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fashe : MonoBehaviour {

	public GameObject text;
	public GameObject text2;
	public GameObject text3;
	public GameObject text4;
//	public GameObject huoyan;
//	public GameObject huojian;
	public float Speed = 10f;
	private hero_anima playerctr;
	private Animator anima;
	public static int choice = 1;
	private bool fire = false;
	// Update is called once per frame
	void Start(){
		anima = transform.root.GetComponent<Animator>();
		playerctr = transform.root.GetComponent<hero_anima> ();
	}
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			anima.SetTrigger ("fashe");
			fire = true;

		}
	}
	void FixedUpdate(){
		if (fire) {
			if (playerctr.facingRight) {
				if(choice == 1){
					GameObject bulletInstance = Instantiate (text, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
					Rigidbody2D rigid = bulletInstance.GetComponent<Rigidbody2D> ();
					rigid.velocity = new Vector2 (Speed, 0);
					Destroy (bulletInstance, 3f);
				}
				if(choice == 2){
					GameObject bulletInstance = Instantiate (text2, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
					Rigidbody2D rigid = bulletInstance.GetComponent<Rigidbody2D> ();
					rigid.velocity = new Vector2 (Speed, 0);
					Destroy (bulletInstance, 3f);
				}
				if(choice == 3){
					GameObject bulletInstance = Instantiate (text3, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
					Rigidbody2D rigid = bulletInstance.GetComponent<Rigidbody2D> ();
					rigid.velocity = new Vector2 (Speed, 0);
					Destroy (bulletInstance, 3f);
				}
				if(choice == 4){
					GameObject bulletInstance = Instantiate (text4, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
					Rigidbody2D rigid = bulletInstance.GetComponent<Rigidbody2D> ();
					rigid.velocity = new Vector2 (Speed, 0);
					Destroy (bulletInstance, 3f);
				}
//				if(choice == 5){
//					GameObject bulletInstance = Instantiate (huoyan, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
//					Rigidbody2D rigid = bulletInstance.GetComponent<Rigidbody2D> ();
//					rigid.velocity = new Vector2 (Speed, 0);
//					Destroy (bulletInstance, 3f);
//				}
//				if(choice == 6){
//					GameObject bulletInstance = Instantiate (huojian, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
//					Rigidbody2D rigid = bulletInstance.GetComponent<Rigidbody2D> ();
//					rigid.velocity = new Vector2 (Speed, 0);
//					Destroy (bulletInstance, 3f);
//				}

			} else {
				if (choice == 1) {
					GameObject bulletInstance = Instantiate (text, transform.position, Quaternion.Euler (new Vector3 (0, 180f, 0)));
					Rigidbody2D rigid = bulletInstance.GetComponent<Rigidbody2D> ();
					rigid.velocity = new Vector2 (-Speed, 0);
					Destroy (bulletInstance, 3f);
				}
				if (choice == 2) {
					GameObject bulletInstance = Instantiate (text2, transform.position, Quaternion.Euler (new Vector3 (0, 180f, 0)));
					Rigidbody2D rigid = bulletInstance.GetComponent<Rigidbody2D> ();
					rigid.velocity = new Vector2 (-Speed, 0);
					Destroy (bulletInstance, 3f);
				}
				if (choice == 3) {
					GameObject bulletInstance = Instantiate (text3, transform.position, Quaternion.Euler (new Vector3 (0, 180f, 0)));
					Rigidbody2D rigid = bulletInstance.GetComponent<Rigidbody2D> ();
					rigid.velocity = new Vector2 (-Speed, 0);
					Destroy (bulletInstance, 3f);
				}
				if (choice == 4) {
					GameObject bulletInstance = Instantiate (text4, transform.position, Quaternion.Euler (new Vector3 (0, 180f, 0)));
					Rigidbody2D rigid = bulletInstance.GetComponent<Rigidbody2D> ();
					rigid.velocity = new Vector2 (-Speed, 0);
					Destroy (bulletInstance, 3f);
				}
//				if (choice == 5) {
//					GameObject bulletInstance = Instantiate (huoyan, transform.position, Quaternion.Euler (new Vector3 (0, 180f, 0)));
//					Rigidbody2D rigid = bulletInstance.GetComponent<Rigidbody2D> ();
//					rigid.velocity = new Vector2 (-Speed, 0);
//					Destroy (bulletInstance, 3f);
//				}
//				if (choice == 6) {
//					GameObject bulletInstance = Instantiate (huojian, transform.position, Quaternion.Euler (new Vector3 (0, 180f, 0)));
//					Rigidbody2D rigid = bulletInstance.GetComponent<Rigidbody2D> ();
//					rigid.velocity = new Vector2 (-Speed, 0);
//					Destroy (bulletInstance, 3f);
//				}
			}
			fire = false;	
		}
	}
}
