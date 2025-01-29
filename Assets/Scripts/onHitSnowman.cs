using UnityEngine;

public class onHitSnowman : MonoBehaviour
{

    public bool isSnowmanHit = false;
    [Header("Audio")]
    [SerializeField] private AudioSource OuchAudio;
    [SerializeField] private AudioSource SnowballAudio;
    [Header("Reference Scripts")]
    [SerializeField] private SnowmanMovement snowmanMovement;
    void SnowmanLooksAtCamera()
    {

        Vector3 targetPosition = Camera.main.transform.position;
        targetPosition.y = gameObject.transform.position.y; //keep the snowman upright
        gameObject.transform.LookAt(targetPosition);
        snowmanMovement.PauseMovement(); //Stop the snowman moving
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Snowball"))
        {

            isSnowmanHit = true;
            Transform splatAnimation = collision.gameObject.transform.Find("Splat");

            collision.gameObject.GetComponent<Renderer>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;


            if (splatAnimation.GetComponent<Animator>() != null )
            {
                splatAnimation.GetComponent<Animator>().SetTrigger("break");

                gameObject.GetComponent<Animator>().SetTrigger("Jump"); //make the snowman jump

                SnowmanLooksAtCamera();

                gameObject.GetComponent<Animator>().SetTrigger("Sad"); //make snowman get sad

                SnowballAudio.Play();
                OuchAudio.Play();
            }

        }
    }
}
