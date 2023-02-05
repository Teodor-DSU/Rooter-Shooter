using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private float timeBetweenSpawn = 3f;
    [SerializeField] private int amountInBatch = 3;
    
    private int currentSpawnPoint = 0;
    private bool canSpawn = true;
    
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnMoreDudes());
        }
    }

    private IEnumerator SpawnMoreDudes()
    {
        canSpawn = false;
        for (int i = 0; i < amountInBatch; i++)
        {
            int chosenEnemy = Random.Range(0, enemies.Count);
            Instantiate(enemies[chosenEnemy], spawnPoints[currentSpawnPoint].transform.position, Quaternion.identity, MoveTowardsPlayer.Enemies);
            NextSpawnPoint();
        }
        yield return new WaitForSeconds(timeBetweenSpawn);
        canSpawn = true;
    }

    private void NextSpawnPoint()
    {
        if (currentSpawnPoint == spawnPoints.Count - 1)
        {
            currentSpawnPoint = 0;
        }
        else
        {
            currentSpawnPoint++;
        }
    }
}
