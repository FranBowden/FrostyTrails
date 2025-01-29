using UnityEngine;

public class DetectSnowballNearCamera : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] private SnowmanMovement SnowmanMovement;

    [Header("Audio")]
    [SerializeField] private AudioSource OuchAudio;
    [SerializeField] private AudioSource SnowballAudio;
    [SerializeField] private AudioSource meltingAudio;
    [SerializeField] private AudioSource WhisleAudio;

    [Header("Gameobjects")]
    [SerializeField] private Animator snowDripAnimation;
    [SerializeField] private float radius = 0.2f;
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("SnowmanSnowball"))
            {
                Destroy(colliders[i]); //destroy snowball coming towards cam
                WhisleAudio.Stop();
                SnowballAudio.Play();
                meltingAudio.Play();
                OuchAudio.Play();
                snowDripAnimation.SetTrigger("Drip");
                WhisleAudio.Play();
                SnowmanMovement.ResumeMovement();

            }


        }
    }
}
