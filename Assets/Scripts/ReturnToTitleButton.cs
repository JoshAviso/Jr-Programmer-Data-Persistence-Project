using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitleButton : MonoBehaviour
{
    [SerializeField] private String _titleMenuName;
    public void ReturnToTitle(bool clearPlayerName)
    {
        if (String.IsNullOrEmpty(_titleMenuName)) return;
        SceneManager.LoadScene(_titleMenuName);

        StateTracker.Instance.SaveCurrentPlayerScore();
        StateTracker.Instance.ClearCurrentPlayer(clearPlayerName);
        StateTracker.Instance.ExportHighscores();
    }
}
