using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable] public struct HighscoreData { public String PlayerName; public int Score; }
[Serializable] public struct HighscoreList { public List<HighscoreData> HighScores; }
public class StateTracker : MonoBehaviour
{
    [SerializeField] private String _highscoreFile = "highscores.sav";
    [SerializeField] private int _maxNumberOfHighscores = 5;

    public String ActivePlayerName { get; private set; }
    public int ActivePlayerScore { get; private set; } = 0;
    public HighscoreList Highscores;

    static public StateTracker Instance { get; private set; }
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        LoadHighscores();
    }
    private void LoadHighscores()
    {
        Highscores.HighScores ??= new List<HighscoreData>();
        if (!File.Exists(Application.persistentDataPath + "/" + _highscoreFile)) return;
        String json = File.ReadAllText(Application.persistentDataPath + "/" + _highscoreFile);
        if (String.IsNullOrEmpty(json)) return;

        Highscores = JsonUtility.FromJson<HighscoreList>(json);
    }
    public void ExportHighscores()
    {
        if (Highscores.HighScores == null) return;
        String json = JsonUtility.ToJson(Highscores);
        if (String.IsNullOrEmpty(json)) return;

        File.WriteAllText(Application.persistentDataPath + "/" + _highscoreFile, json);
    }
    public void SaveCurrentPlayerScore()
    {
        if (ActivePlayerName == null) return;
        Highscores.HighScores ??= new List<HighscoreData>();

        int highscoreCount = Highscores.HighScores.Count;
        if (highscoreCount >= _maxNumberOfHighscores)
        {
            HighscoreData lowest = Highscores.HighScores[highscoreCount - 1];
            if (ActivePlayerScore < lowest.Score) return;

            Highscores.HighScores.RemoveAt(highscoreCount - 1);
        }

        Highscores.HighScores.Add(new HighscoreData { PlayerName = ActivePlayerName, Score = ActivePlayerScore });
        Highscores.HighScores.Sort((a, b) => b.Score.CompareTo(a.Score));
        return;
    }
    public void ClearCurrentPlayer(bool includingName)
    {
        if (includingName) ActivePlayerName = "";
        ActivePlayerScore = 0;
    }
    public void SetActivePlayerScore(int score)
    {
        ActivePlayerScore = score;
    }
    public void SetActivePlayerName(String name)
    {
        ActivePlayerName = name;
    }
}
