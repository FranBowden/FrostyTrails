using UnityEngine;
using UnityEngine.UIElements;


public class SnowmanThrowBall : MonoBehaviour
{
    [Header("Gameobjects")]
    [SerializeField] private GameObject snowmanArm;
    [SerializeField] private GameObject snowmanSnowball;



    [SerializeField] private float force = 15f;
    private float speed = 2.0f;
    private bool snowballMoving = false;
    private Transform arCamera;
    
    void Start()
    {
        arCamera = Camera.main.transform;
    }
    public void ThrowSnowballAtCam()
    {
        GameObject newSnowmanSnowball = Instantiate(snowmanSnowball, snowmanArm.transform.position, snowmanSnowball.transform.rotation);

       newSnowmanSnowball.GetComponent<Rigidbody>().AddForce(-arCamera.forward * force, ForceMode.Impulse); //so we need it going towards cam

    }
    /*
    private void Update()
    {

        if (snowball.activeSelf) //if the snowball is active
        {
            if (snowballMoving) //and it is moving
            {
                //snowball.transform.position = Vector3.MoveTowards(snowball.transform.position, arCamera.position, speed * Time.deltaTime); //move snowball towards the camera
            }

            if (snowball.transform.position == arCamera.position) //if the snowball reaches the position of where the camera is at
            {
                //play audio effects

                WhisleAudio.Stop();
                SnowballAudio.Play();
                meltingAudio.Play();
                OuchAudio.Play();
               
                //snap snowball to snowman position
                snowball.transform.position = snowmanArm.transform.position;
                snowball.SetActive(false); //make the snowball invisable
                snowballMoving = false;
               // snowball.GetComponent<Renderer>().enabled = false;

                snowballDripAnim.SetTrigger("Drip");
                WhisleAudio.Play();
                SnowmanMovement.ResumeMovement();
            }
        }
    */


}
