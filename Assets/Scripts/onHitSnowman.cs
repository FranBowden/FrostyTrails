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
        targetPosition.y = gameObject.transform.position.y; //camera y is the same as snowmans position y
        gameObject.transform.LookAt(targetPosition);//snowman look at camera
        snowmanMovement.PauseMovement(); //Stop the snowman moving
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Snowball"))
        {

            isSnowmanHit = true;

            Transform splatAnimation = collision.gameObject.transform.Find("Splat");
            Transform Trail = collision.gameObject.transform.Find("Trail");

            collision.gameObject.GetComponent<Renderer>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            Trail.gameObject.SetActive(false);


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
