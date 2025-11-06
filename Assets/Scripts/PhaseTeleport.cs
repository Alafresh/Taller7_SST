using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PhaseTeleport : MonoBehaviour
{
    public GameObject tp_volumeParent;
    private Volume volume;
    private Vignette vignette;
    private ColorAdjustments colorAdjustments;

    private float tp_effect_initialIntensity;
    public float tp_effect_endTime = 1f;


    public GameObject hurtVolume;
    private Volume  h_volume;
    private Vignette hv_vignette;

    private float hv_effect_initialIntensity;
    public float hv_effect_endTime = 5f;


    public GameObject savedVolume;
    private Volume s_volume;
    private Vignette s_vignette;

    private float s_effect_initialIntensity;
    public float s_effect_endTime = 5f;


    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject player;

    public Animator animatorBrick;
    public Animator animatorAirCompressor;

    private bool hasTeleportedOneTime = false;
    private bool firstAccidentOccur = false;

    public ObjectSelection objectSelection;

    [SerializeField] private TareaManager tareaManager;
    void Start()
    {
        volume = tp_volumeParent.GetComponent<Volume>();
        volume.profile.TryGet<Vignette>(out vignette);
        volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
        if (vignette != null) 
        {
            tp_effect_initialIntensity = vignette.intensity.value;
        }

        h_volume = hurtVolume.GetComponent<Volume>();
        h_volume.profile.TryGet<Vignette>(out hv_vignette);
        if (hv_vignette != null)
        {
            hv_effect_initialIntensity = hv_vignette.intensity.value;
        }

        s_volume = savedVolume.GetComponent<Volume>();
        s_volume.profile.TryGet<Vignette>(out s_vignette);
        if (s_vignette != null)
        {
            s_effect_initialIntensity = s_vignette.intensity.value;
        }
    }
    public void ActivateVolume() 
    {
        if (volume == null || vignette == null) return;
        Debug.Log("ActivateVolume()");
        StartCoroutine(FadeOut());
    }
    private void DeactivateVolume()
    {
        if (volume == null || vignette == null) return;
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut() 
    {
        Debug.Log("FadeOut()");
        float elapsedTime = 0f;
        while (elapsedTime < tp_effect_endTime) 
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / tp_effect_endTime;
            vignette.intensity.value = Mathf.Lerp(tp_effect_initialIntensity, 1, t);
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
        while (elapsedTime < tp_effect_endTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / tp_effect_endTime;
            vignette.intensity.value = Mathf.Lerp(1f, tp_effect_initialIntensity, t);
            colorAdjustments.colorFilter.value = Color.Lerp(Color.black, Color.white, t);
            yield return null;
        }
        StartCoroutine(Accidents());
    }
    IEnumerator Accidents()
    {
        float elapsedTime = 0f;
        while (true) 
        {
            if (!firstAccidentOccur)
            {
                while (elapsedTime < 5f)
                {
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                animatorBrick.SetTrigger("Fall");
                yield return new WaitUntil(() => animatorBrick.GetCurrentAnimatorStateInfo(0).IsName("FallAccident1"));

                yield return new WaitUntil(() =>
                    animatorBrick.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f &&
                    !animatorBrick.IsInTransition(0)
                );
                animatorBrick.transform.gameObject.SetActive(false);
                firstAccidentOccur = true;
                if (objectSelection.objetosSeleccionados[8] == null || objectSelection.objetosSeleccionados[8].objetoSeleccionado != EppsEnEscena.Objeto.Botas_Protectoras)
                {
                    float hv_activeTime = 0f;
                    hurtVolume.SetActive(true);
                    while (hv_activeTime < hv_effect_endTime)
                    {
                        hv_activeTime += Time.deltaTime;
                        float t = hv_activeTime / hv_effect_endTime;
                        hv_vignette.intensity.value = Mathf.Lerp(hv_effect_initialIntensity, 0f, t);
                        yield return null;
                    }
                    hurtVolume.SetActive(false);
                    hv_vignette.intensity.value = hv_effect_initialIntensity;
                }
                else if (objectSelection.objetosSeleccionados[8].objetoSeleccionado == EppsEnEscena.Objeto.Botas_Protectoras)
                {
                    float sv_activeTime = 0f;
                    savedVolume.SetActive(true);
                    while (sv_activeTime < s_effect_endTime)
                    {
                        sv_activeTime += Time.deltaTime;
                        float t = sv_activeTime / s_effect_endTime;
                        s_vignette.intensity.value = Mathf.Lerp(s_effect_initialIntensity, 0f, t);
                        yield return null;
                    }
                    savedVolume.SetActive(false);
                    s_vignette.intensity.value = s_effect_initialIntensity;
                }
                ActivateVolume();
            }
            else if (firstAccidentOccur)
            {
                while (elapsedTime < 5f)
                {
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                animatorAirCompressor.SetTrigger("Fall");
                yield return new WaitUntil(() => animatorAirCompressor.GetCurrentAnimatorStateInfo(0).IsName("Falling"));

                yield return new WaitUntil(() =>
                    animatorAirCompressor.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f &&
                    !animatorAirCompressor.IsInTransition(0)
                );

                animatorAirCompressor.transform.gameObject.SetActive(false);
                if (objectSelection.objetosSeleccionados[3] == null || objectSelection.objetosSeleccionados[3].objetoSeleccionado != EppsEnEscena.Objeto.Casco)
                {
                    hurtVolume.SetActive(true);
                }
                else if (objectSelection.objetosSeleccionados[8].objetoSeleccionado == EppsEnEscena.Objeto.Botas_Protectoras)
                {
                    float sv_activeTime = 0f;
                    savedVolume.SetActive(true);
                    while (sv_activeTime < s_effect_endTime)
                    {
                        sv_activeTime += Time.deltaTime;
                        float t = sv_activeTime / s_effect_endTime;
                        s_vignette.intensity.value = Mathf.Lerp(s_effect_initialIntensity, 0f, t);
                        yield return null;
                    }
                    savedVolume.SetActive(false);
                    s_vignette.intensity.value = s_effect_initialIntensity;
                }
                break;
            }
        }
    }

    public void Update()
    {
        // For testing purposes, press the T key to activate the teleport effect
        if (Input.GetKeyDown(KeyCode.T))
        {
            ActivateVolume();
        }
    }
}
