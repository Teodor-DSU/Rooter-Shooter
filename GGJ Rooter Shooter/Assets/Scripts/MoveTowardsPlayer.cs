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
    
    public static Transform Enemies = null;
    
    void Start()
    {
        player = PlayerController.ActivePlayer;
        //ChangeChaseTarget();
        if (!Enemies)
            Enemies = GameObject.Find("Enemies").transform;
    }

    void FixedUpdate()
    {
        if (player)
        {
            direction = (player.position - transform.position).normalized;
            transform.position += direction * (speed * Time.fixedDeltaTime);
        }
    }

    public void ChangeChaseTarget(Transform target)
    {
        player = target;
    }
}
