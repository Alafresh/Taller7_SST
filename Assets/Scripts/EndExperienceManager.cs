using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EndExperienceManager : MonoBehaviour
{
    public GameObject tp_volumeParent;
    private Volume volume; 
    private Vignette vignette;
    private ColorAdjustments colorAdjustments;

    private float tp_effect_initialIntensity;
    public float tp_effect_endTime = 1f;

    public AudioSource audioSource;
    void Start()
    {
        volume = tp_volumeParent.GetComponent<Volume>();
        volume.profile.TryGet<Vignette>(out vignette);
        volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
        if (vignette != null)
        {
            tp_effect_initialIntensity = vignette.intensity.value;
        }
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < tp_effect_endTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / tp_effect_endTime;
            vignette.intensity.value = Mathf.Lerp(1f, tp_effect_initialIntensity, t);
            colorAdjustments.colorFilter.value = Color.Lerp(Color.black, Color.white, t);
            yield return null;
        }
        audioSource.Play();
    }
}
