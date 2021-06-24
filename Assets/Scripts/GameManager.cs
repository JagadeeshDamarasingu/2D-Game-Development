using System;
using UnityEngine;

/// <summary>
/// handles Global game preferences and state
///
/// uses Singleton pattern, with thread lock and lazy instantiation
/// </summary>
public sealed class GameManager
{
    private const int LIVES_PER_LEVEL = 3; // Maximum lives per level

    private int LivesRemaining = LIVES_PER_LEVEL;
    private int CurrentLevel = 1;
    private int CurrentLevelScore = 0; // current score of user per level

    /// <summary>
    /// no instances allowed 
    /// </summary>
    private GameManager()
    {
    }

    private static readonly Lazy<GameManager> LazyGameManager = new Lazy<GameManager>(() => new GameManager());
    public static GameManager Instance => LazyGameManager.Value;


    public void OnLevelCompleted()
    {
        CurrentLevelScore += 50;
        CurrentLevel++;
        // TODO load next level
    }

    /// <summary>
    /// can be called to indicate that user has lost one life
    /// </summary>
    public void onLifeLost()
    {
        LivesRemaining--;
        Debug.Log("Lives Remaining: " + LivesRemaining);
    }


    /// <summary>
    /// this method can be used to see if user has any lives remaining
    /// </summary>
    /// <returns>true if any lives are remaining, else false</returns>
    public Boolean HasLivesRemaining()
    {
        return LivesRemaining > 0;
    }

    /// <summary>
    /// Resets the current level state
    /// </summary>
    public void ResetCurrentLevel()
    {
        LivesRemaining = LIVES_PER_LEVEL;
        CurrentLevelScore = 0;
    }
}