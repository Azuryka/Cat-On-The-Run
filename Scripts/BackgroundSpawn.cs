using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawn : MonoBehaviour
{
    public GameObject[] clouds, trees;

    public float delay = 5.0f;
    public Vector2 treePosition;

    [SerializeField]
    private float number;

    void Start()
    {
        StartCoroutine(Background());
    }

    IEnumerator Background()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            number = Random.Range(1.0f, 10.0f);

            if (number >= 4.0f)
            {
                SpawnCloud();
            }
            else { SpawnTree(); }
        }
    }

    public void SpawnCloud()
    {
        var position = new Vector2(10.0f, Random.Range(2.0f, 4.4f));
        Instantiate(clouds[Random.Range(0, clouds.Length)], position, Quaternion.identity);
    }

    public void SpawnTree()
    {
        Instantiate(trees[Random.Range(0, trees.Length)], treePosition, Quaternion.identity);
    }
}
