using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private SceneTransition transition;

    public void StartLoad(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        transition.StartTransition("Fade In");

        yield return new WaitForSeconds(1.7f);

        SceneManager.LoadScene(sceneName);
    }
}
