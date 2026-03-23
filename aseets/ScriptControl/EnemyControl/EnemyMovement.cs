using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float stopDistance = 1.2f;

    private Transform player;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
            player = playerObj.transform;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        float horizontalDistance = Mathf.Abs(player.position.x - transform.position.x);

        if (horizontalDistance <= detectionRange && horizontalDistance > stopDistance)
        {
            float directionX = (player.position.x > transform.position.x) ? 1f : -1f;

            rb.linearVelocity = new Vector2(directionX * moveSpeed, 0f);

            
            if (animator != null)
                animator.SetBool("isWalking", true);

            
            if (sprite != null)
                sprite.flipX = directionX < 0;
        }
        else
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);

           
            if (animator != null)
                animator.SetBool("isWalking", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 leftBoundary = transform.position + Vector3.left * detectionRange;
        Vector3 rightBoundary = transform.position + Vector3.right * detectionRange;
        Gizmos.DrawLine(leftBoundary, rightBoundary);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}