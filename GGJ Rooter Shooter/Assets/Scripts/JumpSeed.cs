using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSeed : MonoBehaviour
{
    [SerializeField]
    private Vector2 Limits = new Vector2(5.0f, 10.0f);
    private Vector3 direction;
    private float power;

    // Update is called once per frame
    void Update()
    {
        transform.position += power * Time.deltaTime * direction;
    }

    public void SetDirection(Vector3 dir, float pow)
    {
        direction = dir;
        power = Mathf.Clamp(pow, Limits.x, Limits.y);
    }
}
