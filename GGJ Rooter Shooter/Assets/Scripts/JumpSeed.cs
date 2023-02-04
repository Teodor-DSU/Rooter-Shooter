using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class JumpSeed : MonoBehaviour
{
    private static int EnemiesLayer = 7;

    public static Transform Enemies = null;

    public GameObject PlayerPrefab;
    
    [SerializeField]
    private Vector2 Limits = new Vector2(5.0f, 10.0f);
    private Vector3 direction;
    private float power;

    private void Start()
    {
        if (!Enemies)
            Enemies = GameObject.Find("Enemies").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += power * Time.fixedDeltaTime * direction;
    }

    public void SetDirection(Vector3 dir, float pow)
    {
        direction = dir;
        power = Mathf.Clamp(pow, Limits.x, Limits.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != EnemiesLayer)
            return;
        
        Destroy(gameObject);
        Destroy(collision.gameObject);

        GameObject player = Instantiate(PlayerPrefab, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        PlayerController.ActivePlayer = player;
        
        CinemachineVirtualCamera cinemachine = Camera.main.GetComponentInChildren<CinemachineVirtualCamera>();
        cinemachine.Follow = player.transform;
        
        //TODO(Vasilis): Start rooting animation
        
        foreach (Transform enemy in Enemies)
        {
            MoveTowardsPlayer chase = enemy.GetComponent<MoveTowardsPlayer>();
            chase.ChangeChaseTarget(player);
        }
    }
}
