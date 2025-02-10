using UnityEngine;

public class enemypatrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public Rigidbody2D rb;
   public float moveSpeed = 3;
   public BoxCollider2D bc;
   public LayerMask listObstacleLayers;
   public float groundCheckRadius = 0.20f;


    void FixedUpdate() {
    rb.linearVelocity = new Vector2(
        moveSpeed = transform.right.normalized.x,
        rb.linearVelocity.y
    );
   }

   bool HasnotTouchedGround() {
    Vector2 detectionPosition = new Vector2(
        bc.bounds.center.x + (
            transform.right.normalized.x *
            (bc.bounds.size.x / 2)
        ),
        bc.bounds.min.y
    );

    return !Physics2D.OverlapCircle(
            detectionPosition,
            groundCheckRadius,
            listObstacleLayers
        );
   }
}
