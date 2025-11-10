using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource complementarySource;

    public AudioClip[] clips;

    void Start()
    {
        PlayByIndex(0);
    }


    private void PlayAudio(AudioClip clip)
    {
        if (audioSource == null || clip == null) return;
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void PlayByIndex(int index)
    {
        if (clips == null) return;
        if (index < 0 || index >= clips.Length) return;
        PlayAudio(clips[index]);
    }
}
