using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MinijuegosObreros {
    public class DropSlot : MonoBehaviour, IDropHandler {

        public Id id;
        GameObject item;
        public bool IsCorrect;
        private readonly int dragChildLimit = 0;
        private readonly int actualChilds = 2;

        public void OnDrop(PointerEventData eventData) {

            if (!item && transform.childCount == (actualChilds + dragChildLimit)) {
                item = DragHandler.objBeingDraged;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;
            }

            if (eventData.pointerDrag.GetComponent<DragHandler>().id == id) {
                IsCorrect = true;
                item.transform.position = transform.position;
            } else {
                IsCorrect = false;
            }
        }

        void Update() {
            if (item != null && item.transform.parent != transform) {
                item = null;
                IsCorrect = false;
            }
        }
    }
}

