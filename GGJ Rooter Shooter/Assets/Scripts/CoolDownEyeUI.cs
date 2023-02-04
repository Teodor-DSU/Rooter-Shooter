using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownEyeUI : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO justShot;
    [SerializeField] private VoidEventChannelSO canShootAgain;
    [SerializeField] private VoidEventChannelSO gotNewHost;
    [SerializeField] private GameObject openEye;
    [SerializeField] private GameObject closedEye;

    private void OnEnable()
    {
        justShot.OnEventRaised += CloseEye;
        canShootAgain.OnEventRaised += OpenEye;
        gotNewHost.OnEventRaised += OpenEye;
    }
    
    private void OnDisable()
    {
        justShot.OnEventRaised -= CloseEye;
        canShootAgain.OnEventRaised -= OpenEye;
        gotNewHost.OnEventRaised -= OpenEye;
    }

    private void OpenEye()
    {
        openEye.SetActive(true);
        closedEye.SetActive(false);
    }

    private void CloseEye()
    {
        closedEye.SetActive(true);
        openEye.SetActive(false);
    }
}
