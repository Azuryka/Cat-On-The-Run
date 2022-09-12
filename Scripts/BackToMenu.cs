using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private SceneLoader loader;

    public void BackToMenuButton()
    {
        gameManager.Pause();
        loader.StartLoad("Menu");
    }
}
