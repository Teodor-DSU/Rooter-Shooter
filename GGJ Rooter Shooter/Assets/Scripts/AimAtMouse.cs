using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour
{
    public Transform JumpSeed;
    
    [SerializeField]
    private Camera mainCam;
    [SerializeField]
    private float LineLength = 2.0f;

    private Vector3 mousePos;
    private LineRenderer lineRenderer;

    private bool jumping;
    private Vector3 jumpDir;
    
    private void Start()
    {
        lineRenderer = transform.GetComponentInChildren<LineRenderer>();
        jumping = false;
    }

    void Update()
    {
        if (jumping)
            return;

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rotZ);
        
        jumpDir = -rotation; jumpDir.z = 0.0f;
        float jumpPower = jumpDir.magnitude;
        
        if (Input.GetButtonUp("Fire2"))
        {
            jumping = true;
            HideJumpAim();
            Transform seed = Instantiate(JumpSeed, transform.position, Quaternion.Euler(0.0f, 0.0f, rotZ));
            JumpSeed script = seed.GetComponent<JumpSeed>();
            script.SetDirection(jumpDir.normalized, jumpPower);
        }
        else if (Input.GetButton("Fire2"))
            ShowJumpAim();
        else
            HideJumpAim();
    }

    private void HideJumpAim()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);
    }

    private void ShowJumpAim()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + jumpDir * LineLength);
    }
}
