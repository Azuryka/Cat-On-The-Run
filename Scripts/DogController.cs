using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    void Update()
    {
        if (gameManager.livesSO.Value == 3)
        {
            this.transform.position = new Vector2(-11f, -1.7f);
        }
        else if (gameManager.livesSO.Value == 2)
        {
            this.transform.position = new Vector2(-9f, -1.7f);
        }
        else if (gameManager.livesSO.Value == 1)
        {
            this.transform.position = new Vector2(-8f, -1.7f);
        }
        else if (gameManager.livesSO.Value == 0)
        {
            this.transform.position = new Vector2(-6.75f, -1.7f);
        }
    }
}
