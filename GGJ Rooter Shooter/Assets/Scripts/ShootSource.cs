using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSource : MonoBehaviour
{
    [SerializeField] private GameObject seed;
    [SerializeField] private Transform muzzle;
    [SerializeField] private int seedAmount = 1;
    [SerializeField] private float spread = 0f;
    [SerializeField] private float delayBetweenSeeds = 0f;
    [SerializeField] private float cooldown = 0.4f;

    private bool canFire = true;
    
    void Start()
    {
        
    }

    // Update is called once per frame
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
        for (int i = 0; i < seedAmount; i++)
        {
            GameObject Seed = seed;
             var randSpreadX = Random.Range(-spread, spread);
             var randSpreadY = Random.Range(-spread, spread);
             Seed.GetComponent<ShootSeed>().direction = new Vector3(transform.right.x + randSpreadX,
                 transform.right.y + randSpreadY, 0f);
             Instantiate(Seed, muzzle.transform.position, transform.rotation);
            yield return new WaitForSeconds(delayBetweenSeeds);
        }

        yield return new WaitForSeconds(cooldown);
        canFire = true;
    }
}
