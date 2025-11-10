using Oculus.Interaction;
using Oculus.Interaction.Input;
using UnityEngine;

public class HandPosesDetector : MonoBehaviour
{
    [SerializeField, Interface(typeof(IHmd))]
    private UnityEngine.Object _hmd;
    private IHmd Hmd { get; set; }

    [SerializeField]
    private ActiveStateSelector[] _poses;

    public PhaseTeleport phaseTeleport;

    public AudioManager audioManager;

    protected virtual void Awake()
    {
        Hmd = _hmd as IHmd;
    }
    void Start()
    {
        for (int i = 0; i < _poses.Length; i++)
        {
            _poses[i].WhenSelected += () => OnThumbsUp();
        }
            
    }

    private void OnThumbsUp() 
    {
        audioManager.PlayByIndex(1);
        phaseTeleport.ActivateVolume();
    }
}
