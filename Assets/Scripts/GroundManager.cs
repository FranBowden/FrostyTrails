using System;
using UnityEngine;

public class GroundManager : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Snowball")) //if the snowball has collided the ground (missed the snowman)
        {
            Transform splatAnimation = collision.gameObject.transform.Find("Splat");
            Transform Trail = collision.gameObject.transform.Find("Trail");


            collision.gameObject.GetComponent<Renderer>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            Trail.gameObject.SetActive(false);

            if (splatAnimation.GetComponent<Animator>() != null)
            {
                splatAnimation.GetComponent<Animator>().SetTrigger("break");
            }
        }
    }
}
