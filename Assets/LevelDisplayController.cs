using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// a controller for displaying level info into Level Prefab
/// <summary>
public class LevelDisplayController : MonoBehaviour
{

    [SerializeField] private LevelInfo level;
    [SerializeField] private Text levelNameText;
    [SerializeField] private Image artworkImage;
    void Start()
    {
        levelNameText.text = level.levelName;
        artworkImage.sprite = level.artWork;
    }
}
