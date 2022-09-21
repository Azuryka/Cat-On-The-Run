using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIManager ui;

    [SerializeField]
    private SceneLoader sceneLoader;

    public IntSO levelSO;

    public IntSO objectiveSO;

    public IntSO scoreSO;

    public IntSO currentObjectiveSO;

    public IntSO livesSO;

    public bool inGame;

    public bool pause = false;

    public string sceneName;

    private void Awake()
    {
        if (sceneName == "Level")
        {
            inGame = true;
            livesSO.Value = 3;
            currentObjectiveSO.Value = 0;
        }
        else { inGame = false; }
    }

    private void Update()
    {
        if (inGame && Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (inGame && livesSO.Value <= 0)
        {
            sceneLoader.StartLoad("Results");
            inGame = false;
        }

        if (inGame && currentObjectiveSO.Value == objectiveSO.Value && levelSO.Value != 4)
        {
            sceneLoader.StartLoad("Results");
            inGame = false;
        }
    }

    public void Pause()
    {
        if (!pause)
        {
            Time.timeScale = 0;
            pause = true;
            ui.PausePanel();
        }
        else if (pause)
        {
            Time.timeScale = 1;
            pause = false;
            ui.PausePanel();
        }
    }

    public void LoseLife()
    {
        livesSO.Value--;
        ui.AttLives();
    }

    public void GainPoint()
    {
        scoreSO.Value += 10;
        ui.AttScore();
    }

    public void GainObjectivePoint()
    {
        currentObjectiveSO.Value++;
        ui.AttObjective();
    }
}
