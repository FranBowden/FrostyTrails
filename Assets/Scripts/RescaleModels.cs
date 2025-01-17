using UnityEngine;

public class RescaleModels : MonoBehaviour
{
    [SerializeField] private Transform snowman;
    [SerializeField] private Transform tree;

    private float distance;
    private bool isPinching = false;

    void Update()
    {
        // Check for two-finger touch
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // Calculate the current distance between fingers
            float currentDistance = Vector2.Distance(touch1.position, touch2.position);

            if (!isPinching)
            {
                // Start of a pinch gesture
                isPinching = true;
                distance = currentDistance;
            }
            else
            {
                // Compare the current distance to the previous distance
                float distanceChange = currentDistance - distance;

                if (distanceChange > 0)
                {
                    Debug.Log("Pinching Out (Zooming In)");

                    Vector3 currentScale = transform.localScale;
                    currentScale += new Vector3(0.1f, 0.1f, 0.1f); // Subtract 0.1 on all axes
                    snowman.localScale = currentScale;
                    tree.localScale = currentScale;
                }
                else if (distanceChange < 0)
                {
                    Debug.Log("Pinching In (Zooming Out)");
                    //make object smaller;
                    Vector3 currentScale = transform.localScale;
                    currentScale -= new Vector3(0.1f, 0.1f, 0.1f); // Subtract 0.1 on all axes
                    snowman.localScale = currentScale;
                    tree.localScale = currentScale;
                }

                // Update the previous distance
                distance = currentDistance;
            }
        }
        else
        {
            // Reset when the user lifts fingers
            isPinching = false;
        }
    }
}
