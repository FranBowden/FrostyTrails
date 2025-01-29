using UnityEngine;
using UnityEngine.AI;

public class ThrowSnowball : MonoBehaviour
{
    //previous code to get the snowman to destroy if ball hit him
    //[SerializeField] private GroundCollision GC;
    //[SerializeField] private MiddleSphereCollision MSC;
    //[SerializeField] private GameObject[] snowmanParts;
    //public bool top, middle, bottom = true;
    //public bool hasBeenHit = false;


    [SerializeField] private float force = 10f;

    [Header("Gameobjects")]

    [SerializeField] private GameObject snowman;
    [SerializeField] private GameObject snowball;
    

    private Transform arCamera;


    void Start()
    {
        arCamera = Camera.main.transform; //assign ar cam 
    }


    public void throwSnowball() //player throws the ball
    {

        Vector3 shootDirection = arCamera.forward;
        GameObject newSnowball = Instantiate(snowball, arCamera.position + shootDirection * 0.5f, snowball.transform.rotation);
        newSnowball.GetComponent<Rigidbody>().AddForce(shootDirection * force, ForceMode.Impulse);
    }
}


   /*
    private void Update()
    {

        
        if (hasBeenHit)
        {
            sm.GetComponent<Animator>().enabled = false;

            Debug.LogError("animator disabled: " + !sm.GetComponent<Animator>().enabled);

            Debug.LogError("top:" + top + " middle: " + middle + "bottom: " + bottom);


            for (int i = 0; i <= 1; i++)
            {
                if (snowmanParts[i].GetComponent<Rigidbody>() != null)
                {
                    snowmanParts[i].GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                }
            }


            if (top && !middle && bottom) //top and bottom
            {

                snowmanParts[0].GetComponent<Rigidbody>().isKinematic = false;
            }
            else if (top && middle && !bottom) //top and middle only
            {

                snowmanParts[0].GetComponent<Rigidbody>().isKinematic = false;
                snowmanParts[1].GetComponent<Rigidbody>().isKinematic = false; //make the middle fall first


            }

            else if (top && !middle && !bottom) //top only
            {

                snowmanParts[0].GetComponent<Rigidbody>().isKinematic = false;
            }

            else if (!top && middle && !bottom) //middle only
            {

                snowmanParts[1].GetComponent<Rigidbody>().isKinematic = false;

            }

            else
            {
                hasBeenHit = false;
            }

        
    }


        if (collision.gameObject.CompareTag("Body1"))
        {
            collision.gameObject.SetActive(false);
            top = false;
        }
        else if (collision.gameObject.CompareTag("Body2"))
        {
            collision.gameObject.SetActive(false);
            middle = false;
        }
        else if (collision.gameObject.CompareTag("Body3"))
        {
            collision.gameObject.SetActive(false);
            bottom = false;
        }
        hasBeenHit = true;

    
}

  */