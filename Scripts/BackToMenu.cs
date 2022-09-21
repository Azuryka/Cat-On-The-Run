using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private SceneLoader loader;

    [SerializeField]
    private AudioManager audioManager;

    public void BackToMenuButton()
    {
        if (gameManager.sceneName == "Level")
        {
            gameManager.Pause();
            gameManager.inGame = false;
        }
        audioManager.SEClick();
        loader.StartLoad("Menu");
    }
}
