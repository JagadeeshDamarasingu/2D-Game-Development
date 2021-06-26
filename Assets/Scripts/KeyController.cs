using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controller to detect collision between player and Key Collectible
/// notifies GameManager about Collectible pickup and
/// hides the collectible
/// </summary>
public class KeyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
        GameManager.Instance.OnCollectibleCollected();
    }
}