using System;
using UnityEngine;

public class GroundManager : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Snowball")) //if the snowball has collided the ground (missed the snowman)
        {
            Transform splatAnimation = collision.gameObject.transform.Find("Splat");

            collision.gameObject.GetComponent<Renderer>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

            if (splatAnimation.GetComponent<Animator>() != null)
            {
                splatAnimation.GetComponent<Animator>().SetTrigger("break");
            }
        }
    }
}
