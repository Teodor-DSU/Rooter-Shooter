using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 10;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHealth(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Debug.Log("Aarg, I'm defeated!");
        }
    }
}
