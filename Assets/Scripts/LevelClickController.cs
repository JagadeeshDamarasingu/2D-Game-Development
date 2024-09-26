using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  a click controller for managing clicks on a level
/// <summary>
public class LevelClickController : MonoBehaviour
{

    [SerializeField] private Button button;
    void Start()
    {
        button.onClick.AddListener(() => OnButtonClicked());
    }

    private void OnButtonClicked()
    {
        var levelInfo = gameObject.GetComponent<LevelInfo>();
        SceneManager.LoadScene(levelInfo.sceneName);
    }
}
