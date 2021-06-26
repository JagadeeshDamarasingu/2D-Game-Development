using UnityEngine;

/// <summary>
/// Controls the chomp Enemy
/// </summary>
public class ChompEnemyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D()");
        var playerController = other.gameObject.GetComponent<PlayerController>();
        if (playerController == null) return;
        GameManager.Instance.OnLifeLost();
        if (!GameManager.Instance.HasLivesRemaining())
        {
            playerController.OnPlayerDead();
        }
    }
}