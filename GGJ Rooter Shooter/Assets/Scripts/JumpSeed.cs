using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class JumpSeed : MonoBehaviour
{
    private static int EnemiesLayer = 7;
    
    [SerializeField]
    private Vector2 Limits = new Vector2(5.0f, 10.0f);
    private Vector3 direction;
    private float power;

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
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer != EnemiesLayer)
            return;
        
        Destroy(gameObject);
        Destroy(collision.gameObject);
        
        //TODO(Vasilis): Start rooting animation
    }
}
