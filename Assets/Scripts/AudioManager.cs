using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip introduccíonEPP;
    public AudioClip explicacion;


    void Start()
    {
        audioSource.clip = introduccíonEPP;
        audioSource.Play();
    }

    
    void Update()
    {
        
    }
    private void PlayAudio(AudioClip clip) 
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
