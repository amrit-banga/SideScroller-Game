using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 10f;
    private int direction = 1;

    void Update()
    {
        Vector2 target = currentMovementTarget();
        platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)platform.position).magnitude;
        if (distance < 0.1f) // Lower tolerance to avoid overshooting
        {
            direction *= -1;
        }
    }

    Vector2 currentMovementTarget()
    {
        return direction == 1 ? endPoint.position : startPoint.position;
    }

    private void OnDrawGizmos()
    {
        if (platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(startPoint.position, endPoint.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player is stepping onto the platform
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(this.transform); // Make the player a child of the platform
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player is leaving the platform
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null); // Remove the parent relationship
        }
    }
}
