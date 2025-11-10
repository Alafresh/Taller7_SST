using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

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
    private bool lastAccidentOccur = false;
    private bool playerDied = false;

    public float delayBeforeTeleport = 2f;
    public float delayBeforeAccident1 = 5f;
    public float delayBeforeAccident2 = 10f;

    public ObjectSelection objectSelection;

    [SerializeField] private TareaManager tareaManager;

    public GameObject warningSignParticles;

    public AudioManager audioManager;
    public AudioSource audioSourceComplementary;
    public AudioClip ambulancia;

    public GameObject obreroBueno;
    public Animator animatorObreroBueno;
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
        if (firstAccidentOccur) //En caso de que queramos darle cierto tiempo de espera entre los accidentes
        {
            float elapsedTime = 0f;
            while (elapsedTime < delayBeforeTeleport)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / delayBeforeTeleport;
            }
        }
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
            obreroBueno.transform.position = waypoint1.transform.position + new Vector3(1.5f, 0f, 0f);
            obreroBueno.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
            hasTeleportedOneTime = true;
        }
        else if(hasTeleportedOneTime && !lastAccidentOccur)
        {
            player.transform.position = waypoint2.transform.position;
            obreroBueno.transform.position = waypoint2.transform.position + new Vector3(0f, 0f,1.5f);
            obreroBueno.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (lastAccidentOccur)
        {
            yield break;
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
                while (elapsedTime < delayBeforeAccident1)
                {
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                animatorBrick.SetTrigger("Fall");
                audioManager.PlayByIndex(10);
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
                    audioManager.PlayByIndex(3);
                    while (hv_activeTime < hv_effect_endTime)
                    {
                        hv_activeTime += Time.deltaTime;
                        float t = hv_activeTime / hv_effect_endTime;
                        hv_vignette.intensity.value = Mathf.Lerp(hv_effect_initialIntensity, 0f, t);
                        yield return null;
                    }
                    audioManager.PlayByIndex(6);
                    hurtVolume.SetActive(false);
                    hv_vignette.intensity.value = hv_effect_initialIntensity;
                }
                else if (objectSelection.objetosSeleccionados[8].objetoSeleccionado == EppsEnEscena.Objeto.Botas_Protectoras)
                {
                    float sv_activeTime = 0f;
                    savedVolume.SetActive(true);
                    audioManager.PlayByIndex(2);
                    while (sv_activeTime < s_effect_endTime)
                    {
                        sv_activeTime += Time.deltaTime;
                        float t = sv_activeTime / s_effect_endTime;
                        s_vignette.intensity.value = Mathf.Lerp(s_effect_initialIntensity, 0f, t);
                        yield return null;
                    }
                    audioManager.PlayByIndex(6);
                    savedVolume.SetActive(false);
                    s_vignette.intensity.value = s_effect_initialIntensity;
                }
                audioManager.PlayByIndex(6);
                animatorObreroBueno.SetTrigger("Thumbs Up");
                ActivateVolume();
                yield break;
            }
            else if (firstAccidentOccur)
            {
                while (elapsedTime < delayBeforeAccident2)
                {
                    elapsedTime += Time.deltaTime;
                    if(elapsedTime == (delayBeforeAccident2 * 0.66f)) StartCoroutine(ActivateWarningSign()); audioManager.PlayByIndex(7); audioSourceComplementary.Play();//Pendiente del float por si se quiere cambiar el tiempo en que inicia
                    yield return null;
                }
                animatorAirCompressor.SetTrigger("Fall");
                yield return new WaitUntil(() => animatorAirCompressor.GetCurrentAnimatorStateInfo(0).IsName("Falling"));

                yield return new WaitUntil(() =>
                    animatorAirCompressor.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f &&
                    !animatorAirCompressor.IsInTransition(0)
                );
                lastAccidentOccur = true;
                animatorAirCompressor.transform.gameObject.SetActive(false);
                warningSignParticles.SetActive(false);
                if (objectSelection.objetosSeleccionados[3] == null || objectSelection.objetosSeleccionados[3].objetoSeleccionado != EppsEnEscena.Objeto.Casco)
                {
                    audioManager.PlayByIndex(5);
                    hurtVolume.SetActive(true);
                    playerDied = true;
                }
                else if (objectSelection.objetosSeleccionados[8].objetoSeleccionado == EppsEnEscena.Objeto.Botas_Protectoras)
                {
                    float sv_activeTime = 0f;
                    audioManager.PlayByIndex(4);
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
                yield return StartCoroutine(EndExperience());
                break;
            }
        }
    }
    private IEnumerator ActivateWarningSign ()
    {
        warningSignParticles.SetActive(true);
        yield return null;
    }
    private IEnumerator EndExperience() 
    {
        yield return StartCoroutine(FadeOut());
        if (playerDied)
        {
            audioSourceComplementary.clip = ambulancia;
            audioSourceComplementary.Play();
        }
        yield return new WaitWhile(() => audioSourceComplementary.isPlaying);
        SceneManager.LoadScene("EndingScene");
        yield break;
    }
}
