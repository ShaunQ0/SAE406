using System;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public float moveDirectionX = 0;
    public float moveSpeed = 10;
    public float jumpForce = 7;
    
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public bool isGrounded = false;
    public LayerMask ListGroundlayers;
    public int maxAllowedJumps = 3;
    public int currentNumbersJumps = 0;
    public bool isFacingRight = false;
    public VoidEventChannel onPlayerDeath;

    private void OnEnable() {
        onPlayerDeath.OnEventRaised += Die;
    }

    private void OnDisable() {
        onPlayerDeath.OnEventRaised -= Die;   
    }

    void Start()
    {
        
    }

    void Die() {
        bc.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return; // Bloquer les actions si le jeu est en pause

        moveDirectionX = Input.GetAxis("Horizontal");

        // Vérifiez si le joueur appuie sur le bouton de saut
        if (Input.GetButtonDown("Jump") && currentNumbersJumps < maxAllowedJumps) 
        {
            Jump();
            currentNumbersJumps++;
        }

        if (isGrounded && !Input.GetButton("Jump")) 
        {
            currentNumbersJumps = 0;
        }

        Flip();
    }

    void Flip() {
        if ((moveDirectionX > 0 && !isFacingRight) || (moveDirectionX < 0 && isFacingRight)) 
        {
            transform.Rotate(0, 180, 0);
            isFacingRight = !isFacingRight;
        }
    }

    private void Jump() 
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void FixedUpdate () {
        if (Time.timeScale == 0) 
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // Arrêter les mouvements horizontaux pendant la pause
            return;
        }

        rb.velocity = new Vector2(moveDirectionX * moveSpeed, rb.velocity.y);
        isGrounded = IsGrounded();
    }

    public bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ListGroundlayers);
    }

    private void OnDrawGizmos () {
        if (groundCheck != null) {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
