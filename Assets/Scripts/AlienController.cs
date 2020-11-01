using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Vector2 origPos;
    private Vector2 movement;

    Animator anim;
    int currentAnimState = 0;

    float moveX;
    float moveY;
    public float speed;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        origPos = transform.position;
        anim = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        moveX = 1;
        moveY = 0;
        movement = new Vector2(moveX, moveY);
        rb2d.velocity = (movement * speed);

    }
}
