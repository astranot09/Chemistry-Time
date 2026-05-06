using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ScoreData
{
    public int bestScore;
}


public class BestScoreManager : MonoBehaviour
{
    public static BestScoreManager instance;

    public ScoreData scoreData = new ScoreData();

    private string savePath;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        savePath = Application.persistentDataPath + "/scoredata.json";
        LoadBestScore();
    }

    public void AddScore(int score)
    {
        // kalau score baru lebih tinggi
        if (score > scoreData.bestScore)
        {
            scoreData.bestScore = score;
            SaveBestScore();
        }
    }

    public void SaveBestScore()
    {
        string json = JsonUtility.ToJson(scoreData, true);
        File.WriteAllText(savePath, json);
    }

    public void LoadBestScore()
    {
        if (!File.Exists(savePath)) return;

        string json = File.ReadAllText(savePath);
        scoreData = JsonUtility.FromJson<ScoreData>(json);
    }

    public int GetBestScore()
    {
        return scoreData.bestScore;
    }
}
