using UnityEngine;

public class DetectCollisionPlayer : MonoBehaviour
{
    private PlayerController playerController;
    private ParticleManager particleManager;
    private SoundManager soundManager;    

    // Start is called before the first frame update
    void Start()
    {
        particleManager = FindObjectOfType<ParticleManager>();
        soundManager = FindObjectOfType<SoundManager>();
        playerController = FindObjectOfType<PlayerController>();      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Alien") && playerController.hasPowerUp == false)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(soundManager.explosion, transform.position, 1f);
            Instantiate(particleManager.explosionParticle, transform.position, transform.rotation);
        }
        if (collision.gameObject.CompareTag("Asteroid") && playerController.hasPowerUp == false)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(soundManager.explosion, transform.position, 1f);
            Instantiate(particleManager.explosionParticle, transform.position, transform.rotation);
        }

    }

}
