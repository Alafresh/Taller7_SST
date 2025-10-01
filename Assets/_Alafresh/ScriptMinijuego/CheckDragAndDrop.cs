using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MinijuegosObreros {
    public class CheckDragAndDrop : MonoBehaviour {
        
        [SerializeField] private DropSlot[] drops;
        [SerializeField] private UnityEvent OnCorrect;
        [SerializeField] private UnityEvent OnIncorrect;

        public int checkCounter = 0;
        public void Check() {
            checkCounter++;
            int i = 0;
            if (drops.Length != 0 && drops != null) {
                foreach (var item in drops) {
                    if (item.IsCorrect) {
                        i++;
                        continue;
                    } else if (item.GetComponentInChildren<DragHandler>() != null)
                        item.GetComponentInChildren<DragHandler>().StartPosition();
                }
            }

            if (i == drops.Length)
                OnCorrect.Invoke();
            else
                OnIncorrect.Invoke();
        }
    }
}

