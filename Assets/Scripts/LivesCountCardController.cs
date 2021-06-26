using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesCountCardController : MonoBehaviour, ILivesCountChangeListener
{
    private TextMeshProUGUI _liveRemainingCardText;

    private void Awake()
    {
        _liveRemainingCardText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.AddLivesCountChangeListener(this);
    }

    public void OnLivesCountChanged(int livesRemaining)
    {
        _liveRemainingCardText.text = $"Lives: {livesRemaining.ToString()}";
    }

    private void OnDestroy()
    {
        GameManager.Instance.RemoveLivesCountChangeListener(this);
    }
}