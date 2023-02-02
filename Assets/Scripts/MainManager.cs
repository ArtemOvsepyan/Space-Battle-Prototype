using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public TextMeshProUGUI bestScore;
    public int highScore;
    public bool isBestScore;

    private void Start()
    {
        LoadingHighScore();
        bestScore.text = ShowHighScore();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);      
    }

    [System.Serializable]
    class SaveData
    {
        public int score;
    }

    public void SavingHighScore(int score)
    {
        if (score <= highScore) return;
        highScore = score;

        SaveData data = new SaveData();
        data.score = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);

        if (!isBestScore) isBestScore = true;   
    }

    private void LoadingHighScore()
    {
        isBestScore = File.Exists(Application.persistentDataPath + "/savedata.json");
        if (!isBestScore) return;

        string json = File.ReadAllText(Application.persistentDataPath + "/savedata.json");
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        highScore = data.score;
    }

    public string ShowHighScore()
    {
        return $"best score: {highScore}";
    }
}
