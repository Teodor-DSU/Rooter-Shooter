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

    private Transform camera;
    private Vector3 travelDistance = new Vector3(47.05f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        sprite = transform.GetComponent<SpriteRenderer>();
        oldPosition = PlayerController.ActivePlayer.position.x;
        camera = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        float posX = PlayerController.ActivePlayer.position.x;
        float offset = posX - oldPosition;
        sprite.material.mainTextureOffset += new Vector2(Speed * offset, 0.0f) * Time.deltaTime;
        oldPosition = posX;

        float dist = QuickDistance(camera.position, transform.position);
        if (dist >= 20.0f)
            transform.position += travelDistance;
        else if (dist <= -20.0f)
            transform.position -= travelDistance;
        //transform.position = new Vector3(camera.position.x + offsetX, transform.position.y, 0.0f);
    }

    private float QuickDistance(Vector3 pos0, Vector3 pos1) { return pos0.x - pos1.x; }
    
    // Update is called once per frame
    void Update()
    {
        //-15.45 to 31.6
    }
}
