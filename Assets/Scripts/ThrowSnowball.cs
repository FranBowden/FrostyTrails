using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSnowball : MonoBehaviour
{
    [SerializeField] private SnowmanAnimatorManager AnimManager;
    private Rigidbody ballRb;
    private Transform ballTransform;
    private Transform arCamera;
    private AudioSource snowballAudio;

    [SerializeField] private float forceAmount = 5f;
    [SerializeField] private float dragAmount = 1f;

    void Start()
    {
        arCamera = Camera.main.transform;
        ballRb = GetComponent<Rigidbody>();
        ballRb.linearDamping = dragAmount;
        ballTransform = transform;

        snowballAudio = GetComponent<AudioSource>();
    }


    public void throwSnowball()
    {
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
        if(collision.gameObject.CompareTag("Snowman"))   //if collides with snowman
        {
          
            Debug.Log("Hit snowman");
            if (Camera.main != null)
            {
                Vector3 direction = Camera.main.transform.position - transform.position;
                direction.y = 0;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // Adjust speed with the last parameter
            }
            //  AnimManager.SadSnowmanAnim();

        } 
    }
}
