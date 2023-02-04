using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShootSource : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO playerjumped;
    [SerializeField] private ParticleSystem shootBlood;
    [SerializeField] private GameObject seed;
    [SerializeField] private Transform muzzle;
    [SerializeField] private int seedsPerShot = 1;
    [SerializeField] private int ammunition = 10;
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
        if (Input.GetMouseButtonDown(0) && canFire && ammunition > 0)
        {
            StartCoroutine(Fire());
        }
        else if (Input.GetMouseButtonDown(0) && ammunition > 0)
        {
            Debug.Log("Outta juice");
        }
    }

    private IEnumerator Fire()
    {
        ammunition--;
        canFire = false;
        for (int i = 0; i < seedsPerShot; i++)
        {
            GameObject Seed = seed;
             var randSpreadX = Random.Range(-spread, spread);
             var randSpreadY = Random.Range(-spread, spread);
             Seed.GetComponent<ShootSeed>().direction = new Vector3(transform.right.x + randSpreadX,
                 transform.right.y + randSpreadY, 0f);
             Instantiate(Seed, muzzle.transform.position, transform.rotation);
            yield return new WaitForSeconds(delayBetweenSeeds);
        }
        shootBlood.Play();
        yield return new WaitForSeconds(cooldown);
        canFire = true;
    }

    private void DisableSelf()
    {
        enabled = false;
    }
}
