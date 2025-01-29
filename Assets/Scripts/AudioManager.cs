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
    
        WhistleAudio.Play();
    }


    public void StopWhistle()
    {
        WhistleAudio.Stop();
    }

    public void turnOnSnowTrailAudio()
    {
        snowTrailAudio.Play();
    }

  

    public void MuteAllSound()
    {

        muteIcon.SetActive(true);
        volumeIcon.SetActive(false);
        AudioListener.volume = 0;
    }

    public void UnMuteAllSound()
    {

        muteIcon.SetActive(false);
        volumeIcon.SetActive(true);
        AudioListener.volume = 1;
    }

}
