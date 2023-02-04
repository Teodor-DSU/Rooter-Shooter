using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodTankUI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private VoidEventChannelSO playerJumped;
    [SerializeField] private VoidEventChannelSO playerGotNewHost;
    private Image bloodTank;
    private float currentFill;
    private bool hostless = false;
    private PlayerController pc;
    
    void Start()
    {
        bloodTank = GetComponent<Image>();
        pc = player.GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        playerJumped.OnEventRaised += BloodLess;
        playerGotNewHost.OnEventRaised += ChangePlayer;
    }

    private void OnDisable()
    {
        playerJumped.OnEventRaised -= BloodLess;
        playerGotNewHost.OnEventRaised -= ChangePlayer;
    }

    void Update()
    {
        bloodTank.fillAmount = currentFill;

        if (!hostless)
        {
            currentFill = pc.currentBlood / pc.maxBloodTank;
        }
    }

    private void ChangePlayer()
    {
        player = PlayerController.ActivePlayer;
        pc = player.GetComponent<PlayerController>();
        hostless = false;
    }

    private void BloodLess()
    {
        hostless = true;
        currentFill = 0f;
    }
}
