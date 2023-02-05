using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlienVictory : MonoBehaviour
{
    [SerializeField] private UnityEvent winGame;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            winGame.Invoke();
        }
    }
}
