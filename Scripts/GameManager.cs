using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIManager ui;

    public IntSO levelSO;

    public IntSO objectiveSO;

    public IntSO scoreSO;

    public int lives;

    public int objective;

    public bool inGame;

    private bool pause = false;

    private void Awake()
    {
        lives = 3;
        objective = 0;
    }

    private void Update()
    {
        if (inGame && Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (inGame && lives <= 0)
        {
            print("Game Over");
        }

        if (inGame && objective == objectiveSO.Value)
        {
            print("Level Complete!");
        }
    }

    private void Pause()
    {
        if (!pause)
        {
            Time.timeScale = 0;
            pause = true;
        }
        else if (pause)
        {
            Time.timeScale = 1;
            pause = false;
        }
    }

    public void LoseLife()
    {
        lives--;
        ui.AttLives();
    }

    public void GainPoint()
    {
        scoreSO.Value += 10;
        ui.AttScore();
    }

    public void GainObjectivePoint()
    {
        objective++;
        ui.AttObjective();
    }
}
