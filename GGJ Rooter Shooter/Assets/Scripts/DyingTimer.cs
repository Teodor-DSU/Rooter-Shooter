using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DyingTimer : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO startedDying; 
    [SerializeField] private VoidEventChannelSO gotNewHost;
    [SerializeField] private int secondsTilDie = 5;
    [SerializeField] private GameObject textObject;

    private TMP_Text text;
    private int currentTime;

    private void Start()
    {
        text = textObject.GetComponent<TMP_Text>();
        textObject.SetActive(false);
    }

    private void OnEnable()
    {
        startedDying.OnEventRaised += StartCountDown;
        gotNewHost.OnEventRaised += StopCountDown;
    }
    
    private void OnDisable()
    {
        startedDying.OnEventRaised -= StartCountDown;
        gotNewHost.OnEventRaised -= StopCountDown;
    }

    private void StartCountDown()
    {
        textObject.SetActive(true);
        currentTime = secondsTilDie;
        text.text = currentTime.ToString();
        StartCoroutine(CountDown());
    }

    private void StopCountDown()
    {
        textObject.SetActive(false);
        StopCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1);
            currentTime--;
            text.text = currentTime.ToString();
        }
    }
}
