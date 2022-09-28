using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowResults : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private Image background;

    [SerializeField]
    private GameObject levelResults, infiniteResults;

    [SerializeField]
    private TMP_Text levelTXT, lvlFishTXT, lvlCatFoodTXT, lvlHeartTXT, lvlResultTXT;

    [SerializeField]
    private TMP_Text imFishTXT, imCatFoodTXT, imResultTXT;

    private void Awake()
    {
        if (gameManager.levelSO.Value != 4)
        {
            levelTXT.text = $"Fase {gameManager.levelSO.Value}";
            lvlFishTXT.text = $"{ gameManager.currentObjectiveSO.Value } / { gameManager.objectiveSO.Value }";
            lvlCatFoodTXT.text = $"{gameManager.scoreSO.Value}";
            lvlHeartTXT.text = $"{gameManager.livesSO.Value}";

            if (gameManager.livesSO.Value <= 0)
            {
                lvlResultTXT.text = $"Tente Novamente...";
                lvlResultTXT.color = Color.red;
                background.color = new Color(0.29f, 0, 0.03f, 1);
            }
            else
            {
                lvlResultTXT.text = $"Completo com Sucesso!";
                lvlResultTXT.color = Color.green;
                background.color = new Color(0, 0.29f, 0.22f, 1);

                if (gameManager.levelSO.Value == 1)
                {
                    PlayerPrefs.SetString("level1Complete", "true");
                }

                if (gameManager.levelSO.Value == 2)
                {
                    PlayerPrefs.SetString("level2Complete", "true");
                }
            }
        }
        else
        {
            background.color = new Color(0, 0.29f, 0.22f, 1);

            imFishTXT.text = $"{ gameManager.currentObjectiveSO.Value }";
            imCatFoodTXT.text = $"{gameManager.scoreSO.Value}";

            int finalScore = gameManager.scoreSO.Value + (gameManager.currentObjectiveSO.Value * 10);
            imResultTXT.color = Color.green;
            imResultTXT.text = $"{finalScore} pontos!";
        }
    }

    private void Start()
    {
        if (gameManager.levelSO.Value != 4)
        {
            levelResults.SetActive(true);
        }
        else
        {
            infiniteResults.SetActive(true);
        }
    }
}
