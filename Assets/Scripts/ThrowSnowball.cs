using UnityEngine;

public class ThrowSnowball : MonoBehaviour
{

    //public int snowballHitCount = 0;
    public bool isSnowmanHit = false;
    [SerializeField] private Transform snowman;
    [SerializeField] private SnowmanThrowBall snowmanThrowball;
    [SerializeField] private SnowmanMovement snowmanMovement;
    [SerializeField] private Animator animator;
    [SerializeField] private SnowmanAnimatorManager AnimManager;
    [SerializeField] private TurnOnLights lights;
    [SerializeField] private GameObject Splat;
    [SerializeField] private AudioSource OuchAudio;
    [SerializeField] private AudioSource SnowballAudio;
    [SerializeField] private float forceAmount = 5f;
    [SerializeField] private float dragAmount = 1f;
    
    private Rigidbody ballRb;
    private Transform ballTransform;
    private Transform arCamera;

    void Start() { 
        
        arCamera = Camera.main.transform; //assign ar cam 
        ballRb = GetComponent<Rigidbody>();
        ballRb.linearDamping = dragAmount;
        ballTransform = transform;
    }


    public void throwSnowball() //User throws snowball
    {
        GetComponent<Renderer>().enabled = true; //make snowball visable

        ballTransform.position = arCamera.position + arCamera.forward * 0.5f;
        Vector3 shootDirection = arCamera.forward;

        shootDirection += new Vector3(0, -0.1f, 0);
        shootDirection.Normalize();

        ballRb.AddForce(shootDirection * forceAmount, ForceMode.Impulse);

        ballRb.linearVelocity *= 0.8f;
        Splat.SetActive(false);
    }


    void SnowmanLooksAtCamera()
    {
      
        Vector3 targetPosition = Camera.main.transform.position;
        targetPosition.y = snowman.transform.position.y; //keep the snowman upright
        snowman.transform.LookAt(targetPosition);
        snowmanMovement.PauseMovement(); //Stop the snowman moving
    }


    private void Update()
    {
        if (Splat.GetComponent<Animator>() != null)
        {
            AnimatorStateInfo stateInfo = Splat.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0); 
            if (stateInfo.IsName("Snowball Break") && stateInfo.normalizedTime >= 1.0f) //if splat animation has ffinished
            {
                Splat.SetActive(false);
                Debug.Log($"{Splat} animation ended, disabling animator.");
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Snowman"))  //if snowball collides with snowman
        {
            Splat.SetActive(true);
            Splat.transform.position = gameObject.transform.position;
            Splat.GetComponent<Animator>().SetTrigger("break");


            Debug.Log("Snowball has hit the snowoman");
            isSnowmanHit = true;
            animator.SetTrigger("Jump"); //make the snowman jump when hit

            SnowmanLooksAtCamera(); //the snowman should then look at the camera
            
            animator.SetTrigger("Sad"); //trigger sad animation
            
            //Audio Sounds
            SnowballAudio.Play(); 
            OuchAudio.Play(); 
        }
    }

   

}
