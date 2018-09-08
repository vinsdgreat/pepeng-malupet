using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
    public float jumpForce;   
	public bool grounded;
	private bool startGame = false;

	private Rigidbody2D rb2d;
	public LayerMask whatIsGround;
	private Collider2D playerCollider;
	private Animator playerAnimator;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		playerCollider = GetComponent<Collider2D>();
		playerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (startGame) {
			grounded = Physics2D.IsTouchingLayers(playerCollider, whatIsGround);

			rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
				if(grounded && startGame) {
					jump();
				}
			}

			playerAnimator.SetFloat("Speed", rb2d.velocity.x);
			playerAnimator.SetBool("Grounded", grounded);
		}

		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			startGame = true;
		}
	}

	private void jump() {
		rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
		//rb2d.AddForce(Vector2.up* jumpForce);
	}
}
