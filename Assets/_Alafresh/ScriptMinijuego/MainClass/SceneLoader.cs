using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNewScene(string sceneName) {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName) {
        // Inicia la carga de la escena de forma as�ncrona
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Evita que la escena se active autom�ticamente al terminar de cargar
        asyncLoad.allowSceneActivation = false;

        // Monitorea el progreso
        while (!asyncLoad.isDone) {
            Debug.Log($"Progreso de carga: {asyncLoad.progress * 100}%");

            // Cuando la carga alcanza el 90% (casi lista)
            if (asyncLoad.progress >= 0.9f) {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
