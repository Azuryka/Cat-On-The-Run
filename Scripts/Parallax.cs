using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private string type = "object";

    private void Update()
    {
        if (type == "Wall")
        {
            if (this.transform.position.x < -33.0f)
            {
                this.transform.position = new Vector2(10.12f, this.transform.position.y);
            }
        }
        else if (type == "Strip")
        {
            if (this.transform.position.x < -33.0f)
            {
                this.transform.position = new Vector2(18.15f, this.transform.position.y);
            }
        }
    }
}
