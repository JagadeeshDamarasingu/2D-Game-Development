using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Key: OnTriggerEnter2D");
        GameManager.Instance.OnCollectibleCollected();
        this.gameObject.SetActive(false);
    }
}