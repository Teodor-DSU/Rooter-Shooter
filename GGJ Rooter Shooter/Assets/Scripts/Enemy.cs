using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 10;

    private MoveTowardsPlayer moveScript;
    
    void Start()
    {
        moveScript = GetComponent<MoveTowardsPlayer>();
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
            moveScript.enabled = false;
        }
    }
}
