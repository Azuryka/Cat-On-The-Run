using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private SceneLoader loader;

    [SerializeField]
    private GameManager gameManager;

    public GameObject menuPanel, levelsPanel, instructionsPanel, recordsPanel;

    private void Start()
    {
        menuPanel.SetActive(true);

        levelsPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        recordsPanel.SetActive(false);
    }

    public void PlayButton()
    {
        levelsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void InstructionsButton()
    {
        instructionsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void LevelSelected(int level)
    {
        switch (level)
        {
            case 1:
                gameManager.levelSO.Value = 1;
                gameManager.objectiveSO.Value = 10;
                gameManager.scoreSO.Value = 0;
                break;
            case 2:
                gameManager.levelSO.Value = 2;
                gameManager.objectiveSO.Value = 15;
                gameManager.scoreSO.Value = 0;
                break;
            case 3:
                gameManager.levelSO.Value = 3;
                gameManager.objectiveSO.Value = 20;
                gameManager.scoreSO.Value = 0;
                break;
            case 4:
                break;
        }
        loader.StartLoad("Level");
    }

    public void BackButton(GameObject panelOpen)
    {
        panelOpen.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
