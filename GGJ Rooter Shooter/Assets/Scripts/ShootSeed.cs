using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootSeed : MonoBehaviour
{
    [SerializeField] private UnityEvent shake;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 2;
    [SerializeField] private float lifetime = 3f;
    private float currentLife = 0f;
    private Rigidbody2D rb;
    [HideInInspector] public Vector3 direction;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //rb.velocity = (transform.right.normalized * (speed * Time.deltaTime));
        transform.position += direction * (speed * Time.deltaTime);

        currentLife += Time.deltaTime;
        if (currentLife >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Enemy e))
        {
            e.LoseHealth(damage);
            Destroy(this.gameObject);
        }
    }
}
