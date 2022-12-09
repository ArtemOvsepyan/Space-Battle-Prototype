using UnityEngine;

public class DetectCollisionProjectile : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public AudioClip explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(explosion, transform.position, 1f);
            Instantiate(explosionParticle, transform.position, transform.rotation);
        }
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(explosion, transform.position, 1f);
            Instantiate(explosionParticle, transform.position, transform.rotation);
        }       
    }

}
