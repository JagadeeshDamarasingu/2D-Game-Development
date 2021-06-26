using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Controls the score shown in UI
/// </summary>
public class ScoreCardController : MonoBehaviour, IScoreChangedListener
{
    private TextMeshProUGUI _scoreCardText;

    private void Awake()
    {
        _scoreCardText = gameObject.GetComponent<TextMeshProUGUI>();
    }


    public void OnScoreChanged(int score)
    {
        _scoreCardText.text = $"Score: {score.ToString()}";
    }


    private void Start()
    {
        GameManager.Instance.AddScoreChangeListener(this);
    }

    private void OnDestroy()
    {
        GameManager.Instance.RemoveScoreChangeListener(this); // remove listener so as not to trigger dead listener
    }
}