using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour 
{

	public float speed, jumpForce;
	public bool canJump;
	private int jumpCounter;
	public Transform floorVerify;
	private Animator anim;
	public bool TerminalOn;

	private bool isRun;
	private bool isJumping;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		TerminalOn = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		move();	
		jump();
		animations ();
	}

	void move()
	{
		//Check if the player is touching the key's for moviment to right (D and righ arrow)
		if (Input.GetAxisRaw ("Horizontal") > 0 && !TerminalOn) {   //Move the character while the player pressing the key
			
			isRun = true;
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			//Adjusts the position of the character
			GetComponent<SpriteRenderer> ().flipX = true;

		} else 
		//Check if the player is touching the key's for moviment to left (A and left arrow)
		if (Input.GetAxisRaw ("Horizontal") < 0 && !TerminalOn) {   //Move the character while the player pressing the key
			isRun = true;
			transform.Translate (Vector2.left * speed * Time.deltaTime);
			//Adjusts the position of the character (flip) 
			GetComponent<SpriteRenderer> ().flipX = false;
		} else {
			isRun = false;
			
		} 

	}

	void jump()
	{
		//Define if the character can jump, if the character is touching the floor
		canJump = Physics2D.Linecast(transform.position, floorVerify.position, 1 << LayerMask.NameToLayer("Floor"));
		//Send a bool to animator, referents at if character is touching the floor, for the jump animation
		//print(canJump);
		//anim_control.SetBool("canJump", canJump);
		//Reset the jump counter
		if (canJump) jumpCounter = 0;

		if (!canJump) {
			isJumping = true;
		
		} else {
			isJumping = false;
		}
		//Check if the player pressed the jump button (Space) and (is touching the floor OR has 1 jump only)
		if (Input.GetButtonDown("Jump") && jumpCounter < 1 && !TerminalOn)
		{   //Make the jump
			isJumping = true;
			//GetComponent<Rigidbody2D>().Sleep();
			//GetComponent<Rigidbody2D>().WakeUp();
			GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
			//anim_control.SetTrigger("Jump");
			//Upgrade the jump counter
			jumpCounter++;
			//Reset the time stoped
		}
	}

	void animations(){
		anim.SetBool ("Idle", !isRun && !isJumping);
		anim.SetBool ("Run", isRun && !isJumping);
		anim.SetBool("Jump",isJumping);

	}
}
