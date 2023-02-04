using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScrollTexture : MonoBehaviour
{
    [SerializeField]
    private float Speed = 1.0f;
    private SpriteRenderer sprite;

    private float oldPosition;
    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = transform.GetComponent<SpriteRenderer>();
        oldPosition = PlayerController.ActivePlayer.position.x;
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        float posY = PlayerController.ActivePlayer.position.x;
        float offset =  posY - oldPosition;
        sprite.material.mainTextureOffset += new Vector2(Speed * offset, 0.0f) * Time.deltaTime;
        oldPosition = posY;
        transform.position = new Vector3(transform.position.x, cam.transform.position.y, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
