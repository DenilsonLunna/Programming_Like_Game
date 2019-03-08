using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basics_Movements : MonoBehaviour {
	public float moveSpeed;
	public Animator animPlayer;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	Rigidbody2D rb;
	[Range(1,100)]
	public float JumpVelocity;
	public LayerMask groundLayer;

	private bool isGrounded;
	private bool isRun;


	// Use this for initialization
	void Start () {
		animPlayer = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//is Grounded?
		isGrounded = Physics2D.OverlapArea (new Vector2 (transform.position.x - 0.5f, transform.position.y - 2.7f),
					 new Vector2 (transform.position.x + 0.5f, transform.position.y - -2.7f), groundLayer);
		//Jump Logic
		if (rb.velocity.y < 0) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1f) * Time.deltaTime;
		} else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow)) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1f) * Time.deltaTime;
		}

		animations ();
	
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) { // Right
			Run (KeyCode.RightArrow);
			isRun = true;
		
		} else if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) { // Left
			Run (KeyCode.LeftArrow);
			isRun = true;

		} else {
			isRun = false;
		}
		if ((Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.W)) && isGrounded) { // Jump
			Jump();
		} 
			

	}
	void Run(KeyCode name){
		if (name == KeyCode.RightArrow) {// Run Right
			this.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); // move to Right
			lookFor (-1);//look to Right


		
		} else { // Run Left
			this.transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);// move to Left
			lookFor (1); // look to Left



		
		}

	}
	// Essa logica do pulo eu peguei de um vídeo do youtube segue o Link: https://www.youtube.com/watch?v=7KiK0Aqtmzc&t=622s
	void Jump(){
		rb.velocity = Vector2.up * JumpVelocity;

	}
	// essa função faz com que o objeto vire (olhe) para a direita ou esquerda, sendo 1 olhando para a esquerda 
	// e -1 olhando para a direita
	void lookFor(float l){ 
		this.transform.localScale = new Vector2(l,this.transform.localScale.y);// Look for Left
	}

	void animations(){
		animPlayer.SetBool ("Run", (isRun && isGrounded));
		animPlayer.SetBool ("Idle", (isGrounded && !isRun));
		animPlayer.SetBool ("Jump",!isGrounded);
		animPlayer.SetFloat ("VelVertical", rb.velocity.y);
	}
		

}
