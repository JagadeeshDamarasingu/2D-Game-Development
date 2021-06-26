using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// this controller detects when a player finishes current level
/// </summary>
public class LevelCompleteController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() == null) return;
        GameManager.Instance.OnLevelCompleted();
        Debug.Log("Level Completed!!!");
    }
}