using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Audio")]
    [SerializeField] private AudioSource WhistleAudio;
    [SerializeField] private AudioSource snowTrailAudio;

    [Header("Icons")]
    [SerializeField] private GameObject volumeIcon;
    [SerializeField] private GameObject muteIcon;
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
        turnOffSnowTrailAudio();
    }

    public void turnOnSnowTrailAudio()
    {
        snowTrailAudio.Play();
    }

    public void turnOffSnowTrailAudio()
    {
        snowTrailAudio.Stop();
    }
}
