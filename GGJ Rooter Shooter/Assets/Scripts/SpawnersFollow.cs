using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersFollow : MonoBehaviour
{
    private float offsetX;
    // Start is called before the first frame update
    void Start()
    {
        offsetX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Transform target = PlayerController.ActivePlayer;
        transform.position = new Vector3(target.position.x + offsetX, transform.position.y, 0.0f);
    }
}
