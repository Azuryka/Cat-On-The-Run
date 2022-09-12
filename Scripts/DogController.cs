using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    void Update()
    {
        if (gameManager.lives == 3)
        {
            this.transform.position = new Vector2(-11f, -1.7f);
        }
        else if (gameManager.lives == 2)
        {
            this.transform.position = new Vector2(-9f, -1.7f);
        }
        else if (gameManager.lives == 1)
        {
            this.transform.position = new Vector2(-8f, -1.7f);
        }
        else if (gameManager.lives == 0)
        {
            this.transform.position = new Vector2(-6.75f, -1.7f);
        }
    }
}
