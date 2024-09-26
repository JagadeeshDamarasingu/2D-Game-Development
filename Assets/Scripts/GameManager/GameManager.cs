using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// handles Global game preferences and state
///
/// uses Singleton pattern, with thread lock and lazy instantiation
/// </summary>
public sealed class GameManager
{
    private const int LivesPerLevel = 3; // Maximum lives per level
    private const int RewardPointForCollectible = 10;

    private int _livesRemaining = LivesPerLevel;
    private int _currentLevel = 1;
    private int _currentLevelScore = 0; // current score of user per level

    private readonly List<IScoreChangedListener> _scoreChangedListeners;
    private readonly List<ILivesCountChangeListener> _livesCountChangeListeners;


    /// <summary>
    /// no instances allowed 
    /// </summary>
    private GameManager()
    {
        _scoreChangedListeners = new List<IScoreChangedListener>();
        _livesCountChangeListeners = new List<ILivesCountChangeListener>();
    }

    private static readonly Lazy<GameManager> LazyGameManager = new Lazy<GameManager>(() => new GameManager());
    public static GameManager Instance => LazyGameManager.Value;


    public void AddLivesCountChangeListener(ILivesCountChangeListener listener)
    {
        _livesCountChangeListeners.Add(listener);
        listener.OnLivesCountChanged(_livesRemaining);
    }

    public void RemoveLivesCountChangeListener(ILivesCountChangeListener listener)
    {
        _livesCountChangeListeners.Remove(listener);
    }


    public void AddScoreChangeListener(IScoreChangedListener listener)
    {
        _scoreChangedListeners.Add(listener);
        listener.OnScoreChanged(_currentLevelScore);
    }

    public void RemoveScoreChangeListener(IScoreChangedListener listener)
    {
        _scoreChangedListeners.Remove(listener);
    }


    public void OnLevelCompleted()
    {
        _currentLevelScore += 50;
        _currentLevel++;
        UpdateScoreListeners();
        UpdateLivesRemainingListeners();
        // TODO load next level
    }

    /// <summary>
    /// can be called to indicate that user has lost one life
    /// </summary>
    public void OnLifeLost()
    {
        _livesRemaining--;
        if (HasLivesRemaining())
        {
            SceneManager.LoadScene("MainScene");
            UpdateLivesRemainingListeners();
        }
        else
        {
            SceneManager.LoadScene("LobbyScene");
            ResetCurrentLevel();
        }
    }


    /// <summary>
    /// this method can be used to see if user has any lives remaining
    /// </summary>
    /// <returns>true, if any lives are remaining, else false</returns>
    public bool HasLivesRemaining()
    {
        return _livesRemaining > 0;
    }

    /// <summary>
    /// Resets the current level state
    /// </summary>
    private void ResetCurrentLevel()
    {
        _livesRemaining = LivesPerLevel;
        _currentLevelScore = 0;
        UpdateScoreListeners();
        UpdateLivesRemainingListeners();
    }

    public void OnCollectibleCollected()
    {
        _currentLevelScore += RewardPointForCollectible;
        UpdateScoreListeners();
    }

    private void UpdateLivesRemainingListeners()
    {
        _livesCountChangeListeners.ForEach(listener => listener.OnLivesCountChanged(_livesRemaining));
    }

    private void UpdateScoreListeners()
    {
        _scoreChangedListeners.ForEach(listener => listener.OnScoreChanged(_currentLevelScore));
    }
}