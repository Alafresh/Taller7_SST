
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MinijuegosObreros {

    

    public class MediationProtocol : MonoBehaviour
    {
        [SerializeField] private MiniGamesManager contadorcheck;
        [SerializeField] private UnityEvent OnFirstAttempt;
        [SerializeField] private UnityEvent OnSecondAttempt;
        [SerializeField] private UnityEvent OnThirdAttempt;
        [SerializeField] private UnityEvent OnFourthAttempt;
        [SerializeField] private UnityEvent BucleEvent;

        private void OnEnable() {
            MediationLogic();
            gameObject.SetActive(false);
        }
        private void MediationLogic() {
            switch (contadorcheck.GetContadorCheck()) {
                case 1:
                    OnFirstAttempt.Invoke();
                    break;
                case 2:
                    OnSecondAttempt.Invoke();
                    break;
                case 3:
                    OnThirdAttempt.Invoke();
                    break;
                case 4:
                    OnFourthAttempt.Invoke();
                    break;
                default:
                    BucleEvent.Invoke();
                    break;
            }
        }
    }
}
