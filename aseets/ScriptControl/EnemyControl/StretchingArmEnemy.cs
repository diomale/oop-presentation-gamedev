using UnityEngine;

public class StretchingArmEnemy : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] private float detectionRange = 5f;

    [Header("Arm System")]
    [SerializeField] private Transform hand;
    [SerializeField] private Transform arm;
    [SerializeField] private float handSpeed = 5f;
    [SerializeField] private float maxArmDistance = 6f;

    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            MoveHand();
            UpdateArm();
        }
    }

    void MoveHand()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        Vector2 targetPosition = (Vector2)transform.position + direction * maxArmDistance;

        // Move hand toward the player but limit distance
        hand.position = Vector2.MoveTowards(
            hand.position,
            player.position,
            handSpeed * Time.deltaTime
        );

        float distanceFromBody = Vector2.Distance(transform.position, hand.position);

        // Clamp hand distance so it never exceeds maxArmDistance
        if (distanceFromBody > maxArmDistance)
        {
            hand.position = targetPosition;
        }
    }

    void UpdateArm()
    {
        Vector3 start = transform.position;
        Vector3 end = hand.position;

        Vector3 direction = end - start;
        float distance = direction.magnitude;

        // Rotate arm toward hand
        arm.right = direction.normalized;

        // Stretch arm exactly to hand
        arm.localScale = new Vector3(distance, 1f, 1f);

        // Place arm exactly between body and hand
        arm.position = start + direction * 0.5f;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, maxArmDistance);
    }

}