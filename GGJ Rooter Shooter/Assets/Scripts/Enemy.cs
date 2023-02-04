using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private float damage = 20;
    [SerializeField] private FloatEventChannelSO loseBlood;
    [SerializeField] private GameObject bloodSplatter;
    [SerializeField] private float timeTillVanish = 3f;
    [HideInInspector] public bool controllable = false;

    private bool canHurt = true;
    private MoveTowardsPlayer moveScript;
    
    void Start()
    {
        moveScript = GetComponent<MoveTowardsPlayer>();
    }
    
    public void LoseHealth(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            moveScript.enabled = false;
            controllable = true;
        }
    }

    private void OnDestroy()
    {
        Instantiate(bloodSplatter, transform.position, transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && canHurt)
        {
            loseBlood.RaiseEvent(damage);
            StartCoroutine(WindDown());
        }
    }

    private IEnumerator WindDown()
    {
        canHurt = false;
        yield return new WaitForSeconds(2);
        canHurt = true;
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(timeTillVanish);
        Destroy(gameObject);
    }
}
