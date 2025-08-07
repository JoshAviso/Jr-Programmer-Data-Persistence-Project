using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUILogic : MonoBehaviour
{
    [SerializeField] private String _gameSceneName;
    [SerializeField] private Button _startGameButton;
    public void StartGame()
    {
        if (String.IsNullOrEmpty(_gameSceneName)) return;
        if (String.IsNullOrEmpty(StateTracker.Instance.ActivePlayerName)) return;

        SceneManager.LoadScene(_gameSceneName);
    }
    public void UpdatePlayerName(String name)
    {
        StateTracker.Instance.SetActivePlayerName(name);
    }
    void Update()
    {
        if(_startGameButton == null) return;
        _startGameButton.interactable = !(String.IsNullOrEmpty(_gameSceneName) || String.IsNullOrEmpty(StateTracker.Instance.ActivePlayerName));
    }
}
