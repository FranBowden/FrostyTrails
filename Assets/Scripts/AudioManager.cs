using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource WhistleAudio;
    [SerializeField] private GameObject volumeIcon;
    [SerializeField] private GameObject muteIcon;
//    [SerializeField] private AudioSource SnowTrailAudio;
    public void playWhistle()
    {
        volumeIcon.SetActive(true);
        muteIcon.SetActive(false);

        WhistleAudio.Play();
    }


    public void StopWhistle()
    {
        muteIcon.SetActive(true);
        volumeIcon.SetActive(false);
        WhistleAudio.Stop();
    }
}
