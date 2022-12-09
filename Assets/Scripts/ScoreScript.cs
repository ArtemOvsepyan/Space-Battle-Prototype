using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerController playerController;

    [SerializeField] private float pointValue;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") || (collision.gameObject.CompareTag("Player") && playerController.hasPowerUp))
        {
            gameManager.UpdateScore(pointValue);
        }        
    }
}
