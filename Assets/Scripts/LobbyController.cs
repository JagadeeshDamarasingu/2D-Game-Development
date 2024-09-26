using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// Controls the Options, Preferences and State of Lobby Screen
/// </summary>
public class LobbyController : MonoBehaviour
{
    [FormerlySerializedAs("PlayButton")] [SerializeField]
    private Button playButton;

    [FormerlySerializedAs("QuitButton")] [SerializeField]
    private Button quitButton;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayClicked);
        quitButton.onClick.AddListener(OnQuitClicked);
    }

    private void OnQuitClicked()
    {
        Application.Quit();
    }

    private void OnPlayClicked()
    {
        SceneManager.LoadScene("MainScene");
    }
}