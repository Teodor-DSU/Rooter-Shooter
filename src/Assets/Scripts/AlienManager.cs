using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    [SerializeField] private IntVariableSO enemiesKilled;
    [SerializeField] private int killsTilAlien = 100;
    [SerializeField] private GameObject alien;
    [SerializeField] private List<Transform> alienSpawnPoints;
    
    private bool alienSpawned = false;

    void Start()
    {
        enemiesKilled.Value = 0;
    }

    void Update()
    {
        if (enemiesKilled.Value >= killsTilAlien && !alienSpawned)
        {
            alienSpawned = true;
            
            foreach (Transform spot in alienSpawnPoints)
            {
                Instantiate(alien, spot.position, spot.rotation);
            }
        }
    }
}
