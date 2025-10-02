
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace MinijuegosObreros {
    public class FeedbackState : MonoBehaviour
    {
        public enum States {
            Right,
            Wrong
        }

        [SerializeField, Tooltip("Which feedback status it is, in order to assign the corresponding phrases to it on enable GameObject")]
        private States state = States.Right;
        [SerializeField]
        private bool displaySentencesRandomly = true;

        [Space(15)]
        [SerializeField]
        private string[] rightSentences = {
            "¡Buen trabajo!",
            "¡Vaya! Lo hiciste muy bien.",
            "¡Así se hace!",
            "¡Bien hecho!",
            "¡Acertaste! Sigue así."
        };

        [SerializeField]
        private string[] wrongSentences = {
            "Hay un error. Revisa tu respuesta.",
            "¡Ups! La respuesta no es correcta. Vuelve a intentarlo.",
            "Algo no está bien. Observa con atención.",
            "Fíjate bien y vuelve a intentarlo.",
            "¡Hum! Observa de nuevo. Hay algo que está mal."
        };

        private TMP_Text textTarget;
        public States State { get => state; set => state = value; }

        private void OnEnable() {
            if (displaySentencesRandomly) {
                textTarget = GetComponentInChildren<TMP_Text>();
                textTarget.text = (state == States.Right) && displaySentencesRandomly ? GetRandomSentence(rightSentences) : GetRandomSentence(wrongSentences);
            }
        }

        public string GetRandomSentence(string[] sentences) =>
            sentences[Random.Range(0, sentences.Length)];
    }
}
