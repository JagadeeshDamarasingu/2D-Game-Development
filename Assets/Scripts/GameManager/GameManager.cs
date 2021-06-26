using System;
using System.Collections.Generic;
using UnityEngine;

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

    /// <summary>
    /// no instances allowed 
    /// </summary>
    private GameManager()
    {
        _scoreChangedListeners = new List<IScoreChangedListener>();
    }

    private static readonly Lazy<GameManager> LazyGameManager = new Lazy<GameManager>(() => new GameManager());
    public static GameManager Instance => LazyGameManager.Value;


    public void AddScoreChangeListener(IScoreChangedListener listener)
    {
        _scoreChangedListeners.Add(listener);
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
        // TODO load next level
    }

    /// <summary>
    /// can be called to indicate that user has lost one life
    /// </summary>
    public void OnLifeLost()
    {
        _livesRemaining--;
        Debug.Log("Lives Remaining: " + _livesRemaining);
    }


    /// <summary>
    /// this method can be used to see if user has any lives remaining
    /// </summary>
    /// <returns>true if any lives are remaining, else false</returns>
    public Boolean HasLivesRemaining()
    {
        return _livesRemaining > 0;
    }

    /// <summary>
    /// Resets the current level state
    /// </summary>
    public void ResetCurrentLevel()
    {
        _livesRemaining = LivesPerLevel;
        _currentLevelScore = 0;
        UpdateScoreListeners();
    }

    public void OnCollectibleCollected()
    {
        _currentLevelScore += RewardPointForCollectible;
        Debug.Log("current score: " + _currentLevelScore);
        UpdateScoreListeners();
    }


    private void UpdateScoreListeners()
    {
        _scoreChangedListeners.ForEach(listener => listener.OnScoreChanged(_currentLevelScore));
    }
}