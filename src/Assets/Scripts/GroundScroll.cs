using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    [SerializeField]
    private float Speed = 0.8f;

    private float oldPosition;

    private SpriteRenderer sprite;
    private Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        sprite = transform.GetComponent<SpriteRenderer>();
        oldPosition = PlayerController.ActivePlayer.position.x;
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = PlayerController.ActivePlayer.position.x;
        float offset = posX - oldPosition;
        oldPosition = posX;
        sprite.material.mainTextureOffset += new Vector2(Speed * offset, 0.0f) * Time.fixedDeltaTime;

        transform.position += new Vector3(offset, 0.0f, 0.0f);
    }
}
