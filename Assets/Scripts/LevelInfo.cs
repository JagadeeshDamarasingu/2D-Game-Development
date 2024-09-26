using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// a scriptable object representing a Level
/// <summary>

[CreateAssetMenu(fileName = "New Level Info", menuName = "Level Info")]
public class LevelInfo : ScriptableObject 
{
     public new string levelName;
     public Sprite artWork;

     public string sceneName;

}
