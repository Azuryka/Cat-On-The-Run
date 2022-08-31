using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        this.transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (this.transform.position.x < -30)
        {
            Destroy(this.gameObject);
        }
    }
}
