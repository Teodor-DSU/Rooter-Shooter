using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSource : MonoBehaviour
{
    [SerializeField] private GameObject seed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(seed, transform.position, transform.rotation);
        }
    }
}
