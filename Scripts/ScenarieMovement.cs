using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarieMovement : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private float speed = 1.0f;

    private float velocity;

    [SerializeField]
    private new string name = "name";

    private float depth = 1.0f;

    private void Awake()
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
            case 4:
                break;
        }

        switch (name)
        {
            case "Wall":
                depth = 1.0f;
                break;
            case "Cloud":
                depth = 2.0f;
                break;
            case "Tree":
                depth = 2.0f;
                break;
            case "Strip":
                depth = 1.0f;
                break;
        }
    }

    private void Start()
    {
        velocity = speed / depth;
    }

    private void Update()
    {
        if (name == "Cloud" && this.transform.position.x < -12.0f || name == "Tree" && this.transform.position.x < -12.0f)
        {
            Destroy(this.gameObject);
        }

        this.transform.Translate(-velocity * Time.deltaTime, 0, 0);
    }
}
