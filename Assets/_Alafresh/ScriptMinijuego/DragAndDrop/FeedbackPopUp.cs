using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackPopUp : MonoBehaviour
{
    [SerializeField] Animator anim;

    [SerializeField, Tooltip("Delay before send trigger.")]
    internal float timeBeforeDesactive = 1f;

    [SerializeField, Tooltip("Send this trigger to the animator asosiated to this script.")]
    internal string trigger = "Unshow";

    public void OnEnable() =>
        StartCoroutine(SendTrigger(timeBeforeDesactive));

    private IEnumerator SendTrigger(float delay) {
        yield return new WaitForSeconds(delay);
        anim.SetTrigger(trigger);
    }
}
