using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    public float speed = 1.0f;

    private bool goingUp = true;
    private float floatingSpeed = 0.3f;
    private float upperLimit;
    private float lowerLimit;

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

        upperLimit = this.transform.position.y + 0.1f;
        lowerLimit = this.transform.position.y - 0.1f;
    }

    void Update()
    {
        this.transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (goingUp)
        {
            transform.position += Vector3.up * floatingSpeed * Time.deltaTime;
            if (transform.position.y > upperLimit)
            {
                goingUp = false;
            }
        }
        else
        {
            transform.position += Vector3.down * floatingSpeed * Time.deltaTime;
            if (transform.position.y < lowerLimit)
            {
                goingUp = true;
            }
        }

        if (this.transform.position.x < -30)
        {
            Destroy(this.gameObject);
        }
    }
}
