using System.Reflection;
using UnityEngine;

public class BottomSphereCollision : MonoBehaviour
{
    /*
    [SerializeField] private ThrowSnowball TS;
    private void OnCollisionEnter(Collision collision)
    {
        if(TS.hasBeenHit)
        {
            if(TS.top && !TS.middle && TS.bottom)
            {
                if(collision.gameObject.CompareTag("Body1"))
                {
                    //then its the head
                    if (collision.gameObject.GetComponent<Rigidbody>() != null)
                    {
                        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        TS.hasBeenHit = false; //turned false because the fall has been dealt with
                    }
                }
            }
        }
    }*/
}
