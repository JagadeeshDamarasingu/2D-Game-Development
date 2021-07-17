using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class LevelInfo : ScriptableObject 
{
     public new string levelName;
     public Sprite artWork;

     public string sceneName;

}
