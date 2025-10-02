using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MinijuegosObreros {
    public enum Id {
        BuenUso, MalUso
    }
    public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

        [SerializeField] private Transform itemDraggerParent;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Transform trasformparent;
        public Id id;

        public static GameObject objBeingDraged;
        private Vector3 startPosition;
        private Transform startParent;
        
        public void StartPosition() {
            startParent = transform.parent;
            transform.SetParent(trasformparent);
        }

        #region DragFunctions
        public void OnBeginDrag(PointerEventData eventData) {

            objBeingDraged = gameObject;
            startPosition = transform.position;
            startParent = transform.parent;
            canvasGroup.blocksRaycasts = false;
            transform.SetParent(itemDraggerParent);
        }
        public void OnDrag(PointerEventData eventData) {
            transform.position = Input.mousePosition;
        }
        public void OnEndDrag(PointerEventData eventData) {

            objBeingDraged = null;
            canvasGroup.blocksRaycasts = true;
            if (transform.parent == itemDraggerParent) {
                transform.position = startPosition;
                transform.SetParent(startParent);
            }
        }
        #endregion
    }
}

