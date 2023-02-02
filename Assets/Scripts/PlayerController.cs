using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ParticleManager particleManager;
    private SoundManager soundManager;
    private AudioSource playerAudio;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject powerupIndicator;

    [SerializeField] private float speed;
    private float verticalInput;
    private float horizontalInput;
    private readonly float  xRange = 11.77f;
    private readonly float yRangeDown = 11;
    private readonly float yRangeUp = 23;
    public bool hasPowerUp;       

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = FindObjectOfType<AudioSource>();
        soundManager = FindObjectOfType<SoundManager>();
        particleManager = FindObjectOfType<ParticleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManager();
        BoundFunction();
    }
    // Powerup manager
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(collision.gameObject);
            powerupIndicator.SetActive(true);
            AudioSource.PlayClipAtPoint(soundManager.powerupSound, transform.position, 1f);
            StartCoroutine(PowerupCountdownRoutine());            
        }

        if (collision.gameObject.CompareTag("Alien") && hasPowerUp == true)
        {
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(soundManager.explosion, transform.position, 1f);
            Instantiate(particleManager.explosionParticle, transform.position, transform.rotation);
        }
        if (collision.gameObject.CompareTag("Asteroid") && hasPowerUp == true)
        {
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(soundManager.explosion, transform.position, 1f);
            Instantiate(particleManager.explosionParticle, transform.position, transform.rotation);
        }
    }

    //Powerup Countdown
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        powerupIndicator.SetActive(false);
        
    }
    // Input manager
    public void InputManager()
    {
        //Controller
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(speed * Time.deltaTime * verticalInput * Vector3.up);

        // Launch rockets
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAudio.PlayOneShot(soundManager.rocketLaunch, 0.1f);
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    //Bound function
    public void BoundFunction()
    {
        //Keep player in bounds
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y < yRangeDown)
        {
            transform.position = new Vector3(transform.position.x, yRangeDown, transform.position.z);
        }
        if (transform.position.y > yRangeUp)
        {
            transform.position = new Vector3(transform.position.x, yRangeUp, transform.position.z);
        }
    }


}
