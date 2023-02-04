using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedTravel : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
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
            Destroy(this.gameObject);
        }
    }
}
