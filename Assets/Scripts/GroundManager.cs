using UnityEngine;

public class GroundManager : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            collision.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
