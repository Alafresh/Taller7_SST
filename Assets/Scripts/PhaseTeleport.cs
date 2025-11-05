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

    public GameObject hurtVolume;

    private float initialIntensity;
    public float endTime = 1;


    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject player;

    public Animator animatorBrick;
    public Animator animatorAirCompressor;

    private bool hasTeleportedOneTime = false;
    private bool firstAccidentOccur = false;

    [SerializeField] private TareaManager tareaManager;
    void Start()
    {
        volume = tp_volumeParent.GetComponent<Volume>();
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
        while (elapsedTime < endTime) 
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / endTime;
            vignette.intensity.value = Mathf.Lerp(initialIntensity, 1f, t);
            //WaitForSeconds wait = new WaitForSeconds(0.01f);  Si se ve mal, descomentar esto
            colorAdjustments.colorFilter.value = Color.Lerp(Color.white, Color.black, t);
            yield return null;
        }
        if (!hasTeleportedOneTime)
        {
            player.transform.position = waypoint1.transform.position;
            hasTeleportedOneTime = true; //aquí está el problema
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
            //WaitForSeconds wait = new WaitForSeconds(0.01f);  Si se ve mal, descomentar esto
            colorAdjustments.colorFilter.value = Color.Lerp(Color.black, Color.white, t);
            yield return null;
        }
        StartCoroutine(Accidents());
    }
    IEnumerator Accidents()
    {
        if (!firstAccidentOccur)
        {
            WaitForSeconds TiempoObreroHablando = new WaitForSeconds(10f);
            animatorBrick.SetTrigger("Fall");
            yield return new WaitUntil(() => animatorBrick.GetCurrentAnimatorStateInfo(0).IsName("FallAccident1"));

            yield return new WaitUntil(() =>
                animatorBrick.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f &&
                !animatorBrick.IsInTransition(0)
            );
            animatorBrick.transform.gameObject.SetActive(false);
            firstAccidentOccur = true;
            //Aquí tengo que hacer la comprobación de que el usuario sí tenga las botas
        }
        else if (firstAccidentOccur)
        {
            
            WaitForSeconds TiempoObreroHablando = new WaitForSeconds(5f);
            animatorAirCompressor.SetTrigger("Fall");
            yield return new WaitUntil(() => animatorBrick.GetCurrentAnimatorStateInfo(0).IsName("Falling"));

            yield return new WaitUntil(() =>
                animatorAirCompressor.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f &&
                !animatorAirCompressor.IsInTransition(0)
            );
            animatorAirCompressor.transform.gameObject.SetActive(false);
            //Aquí tengo que hacer la comprobación de que el usuario sí tenga las botas
        }
    }

    public void Update()
    {
        // For testing purposes, press the T key to activate the teleport effect
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Teleport activated");
            ActivateVolume();
        }
    }
}
