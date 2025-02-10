using UnityEngine;

public class enemypatrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public Rigidbody2D rb;
   public float moveSpeed = 3;
   public BoxCollider2D bc;
   public LayerMask listObstacleLayers;
   public float groundCheckRadius = 0.20f;
   public bool isFacingRight = false;
   public float distantceDectection = 0.5f;

    void FixedUpdate() {
        if (rb.linearVelocity.y != 0) {
            return;
        }

    rb.linearVelocity = new Vector2(
        moveSpeed = transform.right.normalized.x,
        rb.linearVelocity.y
    );

    if (HasnotTouchedGround() || HasCollisionWithObstacles()) {
        Flip();
    }
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
   void Flip() {
        if (
        (transform.right.normalized.x > 0 && !isFacingRight) ||
        (transform.right.normalized.x < 0 && isFacingRight)
        ) {
            transform.Rotate(0, 180, 0);
            isFacingRight = !isFacingRight;
        }
    }

    bool HasCollisionWithObstacles() {
        RaycastHit2D hit = Physics2D.Linecast(
            bc.bounds.center,
            bc.bounds.center + new Vector3(
                distantceDectection * transform.right.normalized.x,
                0,
                0
            ),
            listObstacleLayers
        );
        return hit.transform !=null;
    }

    
    
    
    
    
    
    
    void OnDrawGizmos() {
        if (bc != null) {
            Gizmos.DrawLine(
            bc.bounds.center,
            bc.bounds.center + new Vector3(
                distantceDectection * transform.right.normalized.x,
                0,
                0
            )
            );
            Gizmos.color = Color.red;
            Vector2 detectionPosition = new Vector2(
                bc.bounds.center.x + (
                    transform.right.normalized.x *
                    (bc.bounds.size.x / 2)
                ),
                bc.bounds.min.y
            );
            Gizmos.DrawWireSphere(
                detectionPosition,
                groundCheckRadius
            );
        }
    }
}