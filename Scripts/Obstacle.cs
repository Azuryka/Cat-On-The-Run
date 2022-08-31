using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    public float speed = 1.0f;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        switch (gameManager.levelSO.Value)
        {
            case 1:
                speed = 1.5f;
                break;
            case 2:
                speed = 2.5f;
                break;
            case 3:
                speed = 3.5f;
                break;
        }
    }

    void Update()
    {
        this.transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (this.transform.position.x < -35)
        {
            Destroy(this.gameObject);
        }
    }
}
