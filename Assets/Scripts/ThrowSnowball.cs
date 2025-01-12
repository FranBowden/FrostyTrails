using UnityEngine;

public class ThrowSnowball : MonoBehaviour
{
    [SerializeField] private SnowmanThrowBall snowmanThrowball;
    [SerializeField] private Animator animator;
    [SerializeField] private SnowmanAnimatorManager AnimManager;
    [SerializeField] private AudioSource OuchAudio;
    [SerializeField] private AudioSource SnowballAudio;
    [SerializeField] private float forceAmount = 5f;
    [SerializeField] private float dragAmount = 1f;

    private Rigidbody ballRb;
    private Transform ballTransform;
    private Transform arCamera;

    void Start() { 
        arCamera = Camera.main.transform;
        ballRb = GetComponent<Rigidbody>();
        ballRb.linearDamping = dragAmount;
        ballTransform = transform;
    }


    public void throwSnowball()
    {
        GetComponent<Renderer>().enabled = true; //make snowball visable
        ballTransform.position = arCamera.position + arCamera.forward * 0.5f;
        Vector3 shootDirection = arCamera.forward;

        shootDirection += new Vector3(0, -0.1f, 0);
        shootDirection.Normalize();

        ballRb.AddForce(shootDirection * forceAmount, ForceMode.Impulse);

        ballRb.linearVelocity *= 0.8f;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Snowman"))  //if snowball collides with snowman
        {
            Debug.Log("Snowball has hit the snowoman"); //debug log
            animator.SetTrigger("Sad"); //sad triggers the next animation
            SnowballAudio.Play(); //play the snowball sound 
            OuchAudio.Play(); //play the snowman ouch sound
        }
    }

}
