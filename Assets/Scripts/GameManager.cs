using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] alienPrefab;
    [SerializeField] private GameObject[] asteroidPrefab;
    [SerializeField] private GameObject powerupPrefab;

    [SerializeField] private TextMeshProUGUI gameOverScreen;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    [SerializeField] private Button restartButton;

    [SerializeField] private int score;
    [SerializeField] private bool isGameActive;

    private readonly float spawnRangeX = 14;
    private readonly float SpawnRangeY = 25;
    private readonly float spawnTopMaxY = 23;
    private readonly float spawnTopMinY = 11;
    private readonly float spawnPosX = 16;
    

    // Start the game
    void Start()
    {
        isGameActive = true;
        GameActive();

        if (MainManager.Instance != null)
        {
            bestScoreText.text = MainManager.Instance.ShowHighScore();
        }
    }
    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    // Activate when game is over
    public void GameOver()
    {
        if (GameObject.Find("Player") == null)
        {
            MainManager.Instance.SavingHighScore(score);
            bestScoreText.text = MainManager.Instance.ShowHighScore();
            isGameActive = false;
            CancelInvoke();
            gameOverScreen.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);

        }
    }

    public void GameActive()
    {
        if (isGameActive)
        {
            UpdateScore(0);
            SpawnObjects();
        }
    }
    // Restart the game
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); ;
    }

    // Update scores with alien value
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }

    // Spawn aliens
    void SpawnRandomAlien()
    {
        int alienIndex = Random.Range(0, alienPrefab.Length);
        Vector3 spawnPos = new(Random.Range(-spawnRangeX, spawnRangeX), SpawnRangeY, 0);
        Vector3 rotation = new(0, 0, 180);
        Instantiate(alienPrefab[alienIndex], spawnPos, Quaternion.Euler(rotation));
    }

    // Spawn asteroids from left side
    void SpawnAsteroidLeft()
    {
        int asteroidIndex = Random.Range(0, asteroidPrefab.Length);
        Vector3 spawnPos = new(-spawnPosX, Random.Range(spawnTopMinY, spawnTopMaxY), 0);
        Vector3 rotation = new(0, 0, -90);
        Instantiate(asteroidPrefab[asteroidIndex], spawnPos, Quaternion.Euler(rotation));
    }

    // Spawn asteroids from right side
    void SpawnAsteroidRight()
    {
        int asteroidIndex = Random.Range(0, asteroidPrefab.Length);
        Vector3 spawnPos = new(spawnPosX, Random.Range(spawnTopMinY, spawnTopMaxY), 0);
        Vector3 rotation = new(0, 0, 90);
        Instantiate(asteroidPrefab[asteroidIndex], spawnPos, Quaternion.Euler(rotation));
    }

    // Spawn powerup
    void SpawnPowerup()
    {
        Vector3 spawnPos = new(Random.Range(-spawnRangeX, spawnRangeX), SpawnRangeY, 0);
        Vector3 rotation = new(0, 0, 180);
        Instantiate(powerupPrefab, spawnPos, Quaternion.Euler(rotation));
    }

    //Spawner
    public void SpawnObjects()
    {
        InvokeRepeating(nameof(SpawnRandomAlien), 2.0f, 1.0f);
        InvokeRepeating(nameof(SpawnAsteroidLeft), 2.0f, 1.5f);
        InvokeRepeating(nameof(SpawnAsteroidRight), 2.0f, 1.5f);
        InvokeRepeating(nameof(SpawnPowerup), 5.0f, 10.0f);
    }
}
