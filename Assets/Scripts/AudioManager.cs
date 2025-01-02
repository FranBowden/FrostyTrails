using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource WhistleAudio;
//    [SerializeField] private AudioSource SnowTrailAudio;
    public void playWhistle()
    {
        WhistleAudio.Play();
    }
}
