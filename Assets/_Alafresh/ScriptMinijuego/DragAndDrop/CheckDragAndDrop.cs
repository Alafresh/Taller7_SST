using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MinijuegosObreros {
    public class CheckDragAndDrop : MiniGamesManager
    {
        
        [SerializeField] private DropSlot[] drops;
        [SerializeField] private UnityEvent OnCorrect;
        [SerializeField] private UnityEvent OnIncorrect;

        public void Check() {
            SumContadorCheck();
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

            if (i == drops.Length) {
                timer.StopTimer();
                OnCorrect.Invoke();
            }
            else
                OnIncorrect.Invoke();
        }
    }
}

