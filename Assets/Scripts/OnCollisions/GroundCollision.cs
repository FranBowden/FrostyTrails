using System.Reflection;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
  //  [SerializeField] private ThrowSnowball TS;
   // [SerializeField] private GameObject head;
     
    //public bool middleHasHitGround = false;
    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (TS.hasBeenHit)
        {
            if ((TS.top && TS.middle && !TS.bottom) || (!TS.top && TS.middle && !TS.bottom))
            {
                if (collision.gameObject.CompareTag("Body2")) //if collided with the middle
                {
                  
                    if (collision.gameObject.GetComponent<Rigidbody>() != null )
                    {
                        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                  
                    } 

                    if (head.GetComponent<Rigidbody>() != null)
                    {
                        head.GetComponent<Rigidbody>().isKinematic = true;
                    }

                    TS.hasBeenHit = false;

                }
            }

            else if (TS.top && !TS.middle && !TS.bottom)
            {
                if (collision.gameObject.CompareTag("Body1")) //if collided with the head
                {
                    if (collision.gameObject.GetComponent<Rigidbody>() != null)
                    {
                        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        TS.hasBeenHit = false;
                    }
                }
            }
        }*/
    }
}
