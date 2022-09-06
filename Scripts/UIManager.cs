using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    public TMP_Text livesUI, scoreUI, objectiveUI;

    public GameObject panelPause;

    void Start()
    {
        AttLives();
        AttScore();
        AttObjective();
    }

    public void AttLives()
    {
        livesUI.text = $"{gameManager.lives}";
    }

    public void AttScore()
    {
        scoreUI.text = $"{gameManager.scoreSO.Value}";
    }

    public void AttObjective()
    {
        objectiveUI.text = $"{gameManager.objective}/{gameManager.objectiveSO.Value}";
    }

    public void PausePanel()
    {
        if (gameManager.pause == true)
        {
            panelPause.SetActive(true);
        }
        else { panelPause.SetActive(false); }
    }
}
