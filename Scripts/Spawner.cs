using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    public GameObject[] patternsPrefabs;

    [SerializeField]
    private Vector3 position;

    private float timer;

    private void Start()
    {
        switch (gameManager.levelSO.Value)
        {
            case 1:
                timer = 3.5f;
                break;
            case 2:
                timer = 3.0f;
                break;
            case 3:
                timer = 1.5f;
                break;
            case 4:
                timer = 1.5f;
                break;
        }

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            int number = Random.Range(0, patternsPrefabs.Length);

            Instantiate(patternsPrefabs[number], position, Quaternion.identity);

            yield return new WaitForSeconds(timer);
        }
    }
}
