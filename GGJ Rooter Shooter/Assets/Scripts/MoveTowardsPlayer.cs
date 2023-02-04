using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private VoidEventChannelSO playerJumped;
    
    private Transform player = null;
    private Vector3 direction;
    
    void Start()
    {
        player = PlayerController.ActivePlayer;
        //ChangeChaseTarget();
    }

    void FixedUpdate()
    {
        if (player)
        {
            direction = (player.position - transform.position).normalized;
            transform.position += direction * (speed * Time.deltaTime);
        }
    }

    public void ChangeChaseTarget(Transform target)
    {
        player = target;
    }
}
