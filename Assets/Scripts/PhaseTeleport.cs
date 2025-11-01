using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PhaseTeleport : MonoBehaviour
{
    public GameObject volumeParent;
    private Volume volume;
    private Vignette vignette;
    private ColorAdjustments colorAdjustments;

    private float initialIntensity;
    public float endTime = 1;


    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject player;

    private bool hasTeleportedOneTime = false;
    void Start()
    {
        volume = volumeParent.GetComponent<Volume>();
        volume.profile.TryGet<Vignette>(out vignette);
        volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
        if (vignette != null) 
        {
            initialIntensity = vignette.intensity.value;
        }
    }
    public void ActivateVolume() 
    {
        if (volume == null || vignette == null) return;
        FadeOut();
    }
    private void DeactivateVolume()
    {
        if (volume == null || vignette == null) return;
        FadeIn();
    }

    private IEnumerator FadeOut() 
    {
        float elapsedTime = 0f;
        while (elapsedTime < endTime) 
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / endTime;
            vignette.intensity.value = Mathf.Lerp(initialIntensity, 1f, t);
            colorAdjustments.colorFilter.value = Color.Lerp(Color.white, Color.black, t);
            yield return null;
        }
        if (!hasTeleportedOneTime)
        {
            player.transform.position = waypoint1.transform.position;
            hasTeleportedOneTime = true;
        }
        else 
        {
            player.transform.position = waypoint2.transform.position;
        }
        DeactivateVolume();
    }
    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < endTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / endTime;
            vignette.intensity.value = Mathf.Lerp(1f, initialIntensity, t);
            colorAdjustments.colorFilter.value = Color.Lerp(Color.black, Color.white, t);
            yield return null;
        }
    }
}
