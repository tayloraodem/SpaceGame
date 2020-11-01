using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Vector2 origPos;
    private Vector2 movement;

    float moveX;
    float moveY;
    public float speed;

    private bool jumping;
    private bool inAir;
    private bool falling;
    public int jumpHeight;
    public int gravity;
    private int jumpPos;
    public float jumpSpeed;

    Animator anim;
    int currentAnimState = 0;


    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        origPos = transform.position;
        anim = this.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetButtonDown("Jump") && inAir == false)
        {
            jumping = true;
            inAir = true;
        }

        if (jumping)
        {
            moveY = jumpSpeed;
            jumpPos++;
            if (jumpPos > jumpHeight)
            {
                jumping = false;
                jumpPos = 0;
            }
        }

        else if (rb2d.velocity.y == 0)
        {
            inAir = false;
            falling = false;
        }

        else
        {
            moveY = 0;
        }
        

        if (Input.GetButton("Left"))
        {
            moveX = -1;
            
            if(currentAnimState != 2)
            {
                anim.SetInteger("state", 2);
                currentAnimState = 2;
            }
            

        }

        else if (Input.GetButton("Right"))
        {
            moveX = 1;
            
            if (currentAnimState != 1)
            {
                anim.SetInteger("state", 1);
                currentAnimState = 1;
            }
        }

        else
        {
            moveX = 0;

            if (currentAnimState == 1)
            {
                anim.SetInteger("state", 0);
                currentAnimState = 0;
            }

            else if(currentAnimState == 2)
            {
                anim.SetInteger("state", 3);
                currentAnimState = 3;
            }
        }

        movement = new Vector2(moveX, moveY);
        rb2d.velocity = (movement * speed);
    }
}
