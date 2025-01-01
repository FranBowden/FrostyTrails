using UnityEngine;

public class Move : MonoBehaviour
{
    public SafeArea safeArea; // Reference to the SafeArea script
    public float moveSpeed = 1f;
    public float changeDirectionInterval = 3f; // Time before changing direction

    private Vector3 movementDirection;
    private float timer;

    void Start()
    {
        SetRandomDirection();
    }

    void Update()
    {
        // Update movement
        timer += Time.deltaTime;
        if (timer >= changeDirectionInterval)
        {
            SetRandomDirection();
            timer = 0f;
        }

        // Calculate new position
        Vector3 newPosition = transform.position + movementDirection * moveSpeed * Time.deltaTime;

        // Check if the new position is within the safe area
        if (safeArea.IsInsideSafeArea(newPosition))
        {
            transform.position = newPosition;
        }
        else
        {
            // Bounce back or change direction if outside
            SetRandomDirection();
        }
    }

    private void SetRandomDirection()
    {
        // Random direction on the XZ plane
        float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
        movementDirection = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)).normalized;
    }
}

