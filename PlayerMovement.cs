using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;
    private bool grounded;
    

    public LevelManager gameLevelManager;

    public Vector3 respawnPoint;
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.X))
        {
            SceneManager.LoadScene("xdScena");
        }
    }
    void Update()
    {
        
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);

        if (Input.GetKeyDown(KeyCode.W) && grounded || Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "FallDetector")
        {
            gameLevelManager.Respawn();
        }
        if (other.tag == "CheckPoint")
        {
            respawnPoint = other.transform.position;
        }
    }

}