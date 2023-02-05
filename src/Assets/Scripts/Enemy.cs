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
    [SerializeField] private Color controllableColor = Color.red;
    [SerializeField] private IntVariableSO enemiesKilled;
    public Transform playerToSpawn;
    
    [HideInInspector] public bool controllable = false;
    private SpriteRenderer sr;
    private bool canHurt = true;
    private MoveTowardsPlayer moveScript;
    private bool isQuitting = false;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        moveScript = GetComponent<MoveTowardsPlayer>();
    }
    
    public void LoseHealth(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            sr.color = controllableColor;
            moveScript.enabled = false;
            controllable = true;
            StartCoroutine(Die());
        }
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }
    
    private void OnDestroy()
    {
        if (!isQuitting)
        {
            Instantiate(bloodSplatter, transform.position, transform.rotation);
        }
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
        enemiesKilled.Value++;
        Destroy(gameObject);
    }
}
