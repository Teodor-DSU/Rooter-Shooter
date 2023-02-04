using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO PlayerJumped;

    [SerializeField] private float speed = 5f;

    public static Transform ActivePlayer = null;

    private void Awake()
    {
        if (!ActivePlayer)
            ActivePlayer = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void TurnOff()
    {
        this.enabled = false;
    }

    private void OnEnable()
    {
        PlayerJumped.OnEventRaised += TurnOff;
    }

    private void OnDisable()
    {
        PlayerJumped.OnEventRaised -= TurnOff;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector3(inputX, inputY, 0) * (speed * Time.fixedDeltaTime), Space.World);
        //Rigidbody2D rigidbody2D = transform.GetComponent<Rigidbody2D>();
        //rigidbody2D.position += new Vector2(inputX, inputY) * (speed )
    }
}
