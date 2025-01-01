using UnityEngine;

public class ThrowSnowball : MonoBehaviour
{
    [SerializeField] private SnowmanAnimatorManager AnimManager;
    private Rigidbody ballRb;
    private Transform ballTransform;
    private Transform arCamera;
    private AudioSource snowballAudio;
    private Renderer renderer;
    [SerializeField] private float forceAmount = 5f;
    [SerializeField] private float dragAmount = 1f;
    [SerializeField] private AudioSource audio;


    public SnowmanThrowBall snowmanThrowball;

    [SerializeField] private Animator animator;
    void Start()
    {
        

        arCamera = Camera.main.transform;
        ballRb = GetComponent<Rigidbody>();
        ballRb.linearDamping = dragAmount;
        ballTransform = transform;

        snowballAudio = GetComponent<AudioSource>();
        renderer = GetComponent<Renderer>();
    }


    public void throwSnowball()
    {
        this.GetComponent<Renderer>().enabled = true;
        ballTransform.position = arCamera.position + arCamera.forward * 0.5f;
        Vector3 shootDirection = arCamera.forward;

        shootDirection += new Vector3(0, -0.1f, 0);
        shootDirection.Normalize();

        ballRb.AddForce(shootDirection * forceAmount, ForceMode.Impulse);

        ballRb.linearVelocity *= 0.8f;

        snowballAudio.Play();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Snowman"))   //if collides with snowman
        {

            Debug.Log("Hit snowman");

            if (renderer != null)
            {
                renderer.enabled = false;
            }
            audio.Play();
            animator.SetTrigger("Sad");
            snowmanThrowball.ThrowSnowballAtCam();
        }
    }



}
