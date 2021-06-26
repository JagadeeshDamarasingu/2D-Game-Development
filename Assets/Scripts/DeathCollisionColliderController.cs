using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// when a player falls off from platform,
/// this class resets and reloads the current Level
/// </summary>
public class DeathCollisionColliderController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() == null) return;
        GameManager.Instance.OnLifeLost();
    }
}