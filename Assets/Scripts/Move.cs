using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    public SafeArea safeArea; // Reference to the SafeArea script
    public float moveSpeed = 1f;
    private bool isFacingCorrectly = false;
    float angle = 0;
    private Vector3 movementDirection;

    void Start()
    {
        SetRandomDirection();
    }

    void Update()
    {
        Vector3 newPosition = transform.position + movementDirection * moveSpeed * Time.deltaTime;

        if (safeArea.IsInsideSafeArea(newPosition))
        {
            transform.position = newPosition;

        }
        else
        {
            SetRandomDirection();
        }

        if (!isFacingCorrectly)
        {
            if (transform.eulerAngles.y - angle > 0)
            {
                if (transform.eulerAngles.y - angle < 15)
                {
                    transform.Rotate(0, /*transform.eulerAngles.y +*/ 1, 0, Space.World);
                } else
                {
                    transform.Rotate(0, /*transform.eulerAngles.y +*/ angle, 0, Space.World);
                }    
            }
            else
            {
                if (transform.eulerAngles.y - angle > -15)
                {
                    transform.Rotate(0, /*transform.eulerAngles.y +*/ -1, 0, Space.World);
                }
                else
                {
                    transform.Rotate(0, /*transform.eulerAngles.y +*/ -angle, 0, Space.World);
                }
            }
            
        }

        if (transform.eulerAngles.y == angle)
        {
            isFacingCorrectly = true;
        }
            

    }

    private void SetRandomDirection()
    {
        angle = Random.Range(0, 360) * Mathf.Deg2Rad;
        movementDirection = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)).normalized;
        isFacingCorrectly = false;

        

    }

}

