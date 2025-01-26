using UnityEngine;

public class HatFallsOff : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Snowball"))
        {
            //snowball has collided with hat

            if(gameObject.GetComponent<Rigidbody>() == null) {
             gameObject.AddComponent<Rigidbody>();

                transform.parent = null;
            }
        }
    }
}
