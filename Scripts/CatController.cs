using UnityEngine;

public class CatController : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private AudioManager audioManager;

    [SerializeField]
    private CatDamageEffect damageEffect;

    public Vector2[] ways;
    private Vector2 posNow;
    private Vector2 posTarget;

    [SerializeField]
    private int speed;

    void Start()
    {
        posNow = ways[1];
        posTarget = posNow;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, posTarget, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(posNow == ways[1])
            {
                posTarget = ways[0];
                posNow = ways[0];
            }
            else if(posNow == ways[2])
            {
                posTarget = ways[1];
                posNow = ways[1];
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (posNow == ways[0])
            {
                posTarget = ways[1];
                posNow = ways[1];
            }
            else if (posNow == ways[1])
            {
                posTarget = ways[2];
                posNow = ways[2];
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Obstacle" && gameManager.inGame)
        {
            damageEffect.Damage();
            gameManager.LoseLife();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Cat Food" && gameManager.inGame)
        {
            gameManager.GainPoint();
            Destroy(other.gameObject);
            audioManager.SECatFood();
        }
        else if (other.tag == "Fish" && gameManager.inGame)
        {
            gameManager.GainObjectivePoint();
            Destroy(other.gameObject);
            audioManager.SEFish();
        }
    }
}
