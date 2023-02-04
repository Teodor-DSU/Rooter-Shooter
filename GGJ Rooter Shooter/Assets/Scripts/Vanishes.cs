using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanishes : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1f;
    [SerializeField] private ParticleSystem particleSystem;
    
    void Start()
    {
        StartCoroutine(Vanish());
    }

    private IEnumerator Vanish()
    {
        particleSystem.Play();
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
