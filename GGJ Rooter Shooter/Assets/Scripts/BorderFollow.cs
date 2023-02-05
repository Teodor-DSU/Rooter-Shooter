using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderFollow : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform target = PlayerController.ActivePlayer;
        transform.position = new Vector3(target.position.x, transform.position.y, 0.0f);
    }
}
