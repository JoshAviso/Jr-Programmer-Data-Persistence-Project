using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreUpdater : MonoBehaviour
{
    [SerializeField] private List<HighscoreDisplay> highscoreDisplays = new List<HighscoreDisplay>();
    void Update()
    {
        for (int i = 0; i < highscoreDisplays.Count; i++)
        {
            HighscoreDisplay highscoreDisplay = highscoreDisplays[i];
            if (i < StateTracker.Instance.Highscores.HighScores.Count)
            {
                HighscoreData highscoreData = StateTracker.Instance.Highscores.HighScores[i];
                highscoreDisplay.Container.SetActive(true);
                highscoreDisplay.NameDisplay.text = highscoreData.PlayerName;
                highscoreDisplay.TextDisplay.text = highscoreData.Score.ToString();
            }
            else
            {
                highscoreDisplay.Container.SetActive(false);
            }
        }
    }
}
