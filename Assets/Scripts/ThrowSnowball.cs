using UnityEngine;

public class ThrowSnowball : MonoBehaviour
{
    [SerializeField] private Transform snowman;
    [SerializeField] private SnowmanThrowBall snowmanThrowball;
    [SerializeField] private SnowmanMovement snowmanMovement;
    [SerializeField] private Animator animator;
    [SerializeField] private SnowmanAnimatorManager AnimManager;
    [SerializeField] private AudioSource OuchAudio;
    [SerializeField] private AudioSource SnowballAudio;
    [SerializeField] private float forceAmount = 5f;
    [SerializeField] private float dragAmount = 1f;

    private Rigidbody ballRb;
    private Transform ballTransform;
    private Transform arCamera;
    private bool lookatcamera = false;

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


    void SnowmanLooksAtCamera()
    {

        //snowman.transform.Rotate(snowman.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y - 180, snowman.transform.eulerAngles.z, Space.World);

        Vector3 targetPosition = Camera.main.transform.position;
        targetPosition.y = snowman.transform.position.y; // Keep the snowman upright
        snowman.transform.LookAt(targetPosition);
        snowmanMovement.PauseMovement();
    }
    



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Snowman"))  //if snowball collides with snowman
        {
            SnowmanLooksAtCamera();
            Debug.Log("Snowball has hit the snowoman"); //debug log
            animator.SetTrigger("Sad"); //sad triggers the next animation
            SnowballAudio.Play(); //play the snowball sound 
            OuchAudio.Play(); //play the snowman ouch sound
        }
    }

   

}
