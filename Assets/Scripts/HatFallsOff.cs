using UnityEngine;

public class HatFallsOff : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Snowball"))
        {
            //snowball has collided with hat


            Transform splatAnimation = collision.gameObject.transform.Find("Splat");
            Transform Trail = collision.gameObject.transform.Find("Trail");

            collision.gameObject.GetComponent<Renderer>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            Trail.gameObject.SetActive(false);


            if (splatAnimation.GetComponent<Animator>() != null)
            {
                splatAnimation.GetComponent<Animator>().SetTrigger("break");
            }

            if (gameObject.GetComponent<Rigidbody>() == null) {
                 gameObject.AddComponent<Rigidbody>();
                 transform.parent = null;
            }
        }
    }
}
