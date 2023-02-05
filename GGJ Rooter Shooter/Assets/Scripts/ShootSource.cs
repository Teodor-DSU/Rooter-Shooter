using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class ShootSource : MonoBehaviour
{
    [SerializeField] private UnityEvent shake;
    [SerializeField] private VoidEventChannelSO playerjumped;
    [SerializeField] private VoidEventChannelSO justShot;
    [SerializeField] private VoidEventChannelSO canShootAgain;
    [SerializeField] private FloatEventChannelSO shootEventLoseBlood;
    [SerializeField] private ParticleSystem shootBloodSplatterEffect;
    [SerializeField] private GameObject seed;
    [SerializeField] private Transform muzzle;
    [SerializeField] private int seedsPerShot = 1;
    [SerializeField] private float shotBloodCost = 10;
    [SerializeField] private float spread = 0f;
    [SerializeField] private float delayBetweenSeeds = 0f;
    [SerializeField] private float cooldown = 0.4f;

    private bool canFire = true;

    private void OnEnable()
    {
        playerjumped.OnEventRaised += DisableSelf;
    }

    private void OnDisable()
    {
        playerjumped.OnEventRaised -= DisableSelf;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            StartCoroutine(Fire());
        }
    }

    private IEnumerator Fire()
    {
        canFire = false;
        for (int i = 0; i < seedsPerShot; i++)
        {
            ShootSeed();
            yield return new WaitForSeconds(delayBetweenSeeds);
        }
        shootEventLoseBlood.RaiseEvent(shotBloodCost);
        yield return new WaitForSeconds(cooldown);
        canFire = true;
        canShootAgain.RaiseEvent();
    }

    public void ShootSeed()
    {
        GameObject Seed = seed;
        var randSpreadX = Random.Range(-spread, spread);
        var randSpreadY = Random.Range(-spread, spread);
        Seed.GetComponent<ShootSeed>().direction = new Vector3(transform.right.x + randSpreadX,
            transform.right.y + randSpreadY, 0f);
        Instantiate(Seed, muzzle.transform.position, transform.rotation);
        shootBloodSplatterEffect.Play();
        shake.Invoke();
        justShot.RaiseEvent();
    }

    private void DisableSelf()
    {
        enabled = false;
    }
}
