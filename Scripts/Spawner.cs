using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    public GameObject fishPrefab, catFoodPrefab, trashPrefab, gatePrefab, conesPrefab;

    private float timer;

    private float[] y = { 1.04f, -1.61f, -3.39f};

    private void Start()
    {
        switch (gameManager.levelSO.Value)
        {
            case 1:
                timer = 3.0f;
                break;
            case 2:
                timer = 2.5f;
                break;
            case 3:
                timer = 1.5f;
                break;
        }

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            int number = Random.Range(0, 101);

            if (number <= 60)
            {
                int obstacle = Random.Range(1, 4);

                if (obstacle == 1)
                {
                    Gate();
                }
                else if (obstacle == 2)
                {
                    Cones();
                }
                else { Trash(); }
            }
            else if (number > 60)
            {
                int item = Random.Range(0, 11);

                if (item <= 7)
                {
                    CatFood();
                }
                else { Fish(); }
            }

            yield return new WaitForSeconds(timer);
        }
    }

    public void Gate()
    {
        var position = new Vector2(11f, 0.3504038f);
        Instantiate(gatePrefab, position, Quaternion.identity);
    }
    public void Cones()
    {
        var position = new Vector2(11f, -3.36f);
        Instantiate(conesPrefab, position, Quaternion.identity);
    }

    public void Trash()
    {
        var position = new Vector2(11f, -1.35f);
        Instantiate(trashPrefab, position, Quaternion.identity);
    }

    public void CatFood()
    {
        var position = new Vector2(11f, y[Random.Range(0, y.Length)]);
        Instantiate(catFoodPrefab, position, Quaternion.identity);
    }

    public void Fish()
    {
        var position = new Vector2(11f, y[Random.Range(0, y.Length)]);
        Instantiate(fishPrefab, position, Quaternion.identity);
    }
}
