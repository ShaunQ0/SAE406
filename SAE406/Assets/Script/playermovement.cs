using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveDirectionX = 0;
    public float moveSpeed = 10;
    public float jumpForce = 7;
     private bool isGrounded = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirectionX = Input.GetAxis("Horizontal");
 // Vérifiez si le joueur appuie sur le bouton de saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

      private void Jump() 
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }
    private void FixedUpdate () {
        rb.linearVelocity = new Vector2 (
            moveDirectionX * moveSpeed,
            rb.linearVelocity.y 
        );
    }

}
