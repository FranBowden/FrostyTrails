using System;
using UnityEngine;

public class GroundManager : MonoBehaviour
{

    [SerializeField] private GameObject Splat;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Snowball")) //if the snowball has collided the ground (missed the snowman)
        {
            collision.gameObject.GetComponent<Renderer>().enabled = false; //then make the ball invisable
            Splat.GetComponent<Animator>().SetTrigger("break");

        }
    }
}
