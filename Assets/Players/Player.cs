using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D RB;
    public float JumpAmount;
    public bool Jumped;
    public Animator anim;
    public float X;
    public bool isGrounded;
    public LayerMask Ground;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleAnimations();
        HandleJump();

        X = Input.GetAxis("Horizontal")*10;
        RB.velocity = new Vector2(X,RB.velocity.y);
    }
    void HandleJump()
    {
       
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Pressed");
            RB.AddForce(transform.up*JumpAmount,ForceMode2D.Impulse);
            Jumped = true;
            anim.SetTrigger("Jump");
        }
        if (Input.GetButtonUp("Jump") && RB.velocity.y > 0 && Jumped)
        {
            RB.velocity = new Vector2(RB.velocity.x, 0);
            Jumped = false;
        }
        Vector2 feet = transform.position + Vector3.down;
        isGrounded = Physics2D.OverlapCircle(feet, 0.1f, Ground);
    }

    void HandleAnimations()
    {
        anim.SetFloat("Ymomentom", RB.velocity.y);
        anim.SetFloat("Speed",Mathf.Abs(X));
        anim.SetBool("IsGrounded", isGrounded);
    }
}
