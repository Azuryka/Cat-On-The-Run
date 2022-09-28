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
        livesUI.text = $"{gameManager.livesSO.Value}";
    }

    public void AttScore()
    {
        scoreUI.text = $"{gameManager.scoreSO.Value}";
    }

    public void AttObjective()
    {
        if (gameManager.levelSO.Value != 4)
        {
            objectiveUI.text = $"{gameManager.currentObjectiveSO.Value}/{gameManager.objectiveSO.Value}";
        }
        else
        {
            objectiveUI.text = $"{gameManager.currentObjectiveSO.Value}";
        }
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
