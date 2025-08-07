
using UnityEngine;
using UnityEngine.UI;

public class BestScoreUpdater : MonoBehaviour
{
    private Text _text;
    void Start()
    {
        _text = GetComponent<Text>();
    }
    void Update()
    {
        if (_text == null) return;
        if (StateTracker.Instance.Highscores.HighScores == null || StateTracker.Instance.Highscores.HighScores.Count <= 0)
            _text.text = "High Score : -";
        else
        {
            HighscoreData highscore = StateTracker.Instance.Highscores.HighScores[0];
            _text.text = $"High Score : {highscore.PlayerName} : {highscore.Score}";
        }
    }
}
