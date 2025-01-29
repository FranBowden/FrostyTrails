using UnityEngine;
using UnityEngine.UIElements;


public class SnowmanThrowBall : MonoBehaviour
{


    [SerializeField] private float force = 4f;

    [Header("Gameobjects")]
    [SerializeField] private GameObject snowmanArm;
    [SerializeField] private GameObject snowmanSnowball;

  
    private Transform arCamera;
    
    void Start()
    {
        arCamera = Camera.main.transform;
    }
    public void ThrowSnowballAtCam()
    {
        GameObject newSnowmanSnowball = Instantiate(snowmanSnowball, snowmanArm.transform.position, snowmanSnowball.transform.rotation);

        newSnowmanSnowball.GetComponent<Rigidbody>().AddForce(-arCamera.forward * force, ForceMode.Impulse); //need it going towards camera

    }
   
}
