using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private Material transitionMaterial;

    [SerializeField]
    private float transitionTime = 1.0f;

    private float currentTime = 0.0f;

    [SerializeField]
    private string propertyName = "_Progress";

    [SerializeField]
    private string fade = "Fade Out";

    [SerializeField]
    private bool isDone = false;

    private void Start()
    {
        StartTransition("Fade Out");
    }

    private void Update()
    {
        if (isDone)
        {
            StopCoroutine(Transition());
            isDone = false;
        }
    }

    private IEnumerator Transition()
    {
        if (fade == "Fade Out")
        {
            currentTime = 0.0f;
            while (currentTime < transitionTime)
            {
                FadeOut();
                yield return null;
            }
        }
        else
        {
            currentTime = 1.0f;
            while (currentTime > 0.0f)
            {
                FadeIn();
                yield return null;
            }
        }

        isDone = true;
    }

    public void StartTransition(string wichFade)
    {
        fade = wichFade;
        StartCoroutine(Transition());
    }

    private void FadeIn()
    {
        currentTime -= Time.deltaTime;
        transitionMaterial.SetFloat(propertyName, Mathf.Clamp01(currentTime / transitionTime));
    }

    private void FadeOut()
    {
        currentTime += Time.deltaTime;
        transitionMaterial.SetFloat(propertyName, Mathf.Clamp01(currentTime / transitionTime));
    }
}
