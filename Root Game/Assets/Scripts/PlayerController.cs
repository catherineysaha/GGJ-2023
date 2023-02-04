using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 5f;
    public float jumpSpeed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    public Vector3 respawnPoint;
    private bool hasLanded = true;
    //public LevelManager gameLevelManager;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        //gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update() {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        if (isTouchingGround && !hasLanded && rigidBody.velocity.y < 0) {
            hasLanded = true;
        }

        movement = Input.GetAxis("Horizontal");
        if (movement > 0f) {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            //transform.localScale = new Vector2(-.7f, transform.localScale.y);
        } else if (movement < 0f) {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            //transform.localScale = new Vector2(.7f, transform.localScale.y);
        } else {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        if (!isTouchingGround && hasLanded) {
            hasLanded = false;
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround) {
            OnJump();
        }
    }

    void OnJump() {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        hasLanded = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "FallDetector") {
            //gameLevelManager.Respawn();
        }
        if (other.tag == "Checkpoint") {
            respawnPoint = other.transform.position;
        }
    }
}