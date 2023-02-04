using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private VoidEventChannelSO playerJumped;
    
    private GameObject player;
    private Vector3 direction;
    
    void Start()
    {
        ChangeChaseTarget();
    }

    private void OnEnable()
    {
        playerJumped.OnEventRaised += ChangeChaseTarget;
    }

    private void OnDisable()
    {
        playerJumped.OnEventRaised -= ChangeChaseTarget;
    }

    void FixedUpdate()
    {
        direction = (player.transform.position - transform.position).normalized;
        transform.position += direction * (speed * Time.deltaTime);
    }

    private void ChangeChaseTarget()
    {
        player = GameObject.FindWithTag("Player");
    }
}
