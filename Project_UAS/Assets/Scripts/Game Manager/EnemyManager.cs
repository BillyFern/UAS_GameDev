using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    private float spawnTime;
    public Transform[] spawnPoints;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (playerHealth.currentHealth > 0)
        {
            UpdateSpawnTime();

            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void UpdateSpawnTime()
    {
        if (playerHealth.currentHealth <= 250f)
        {
            spawnTime = 3f;
        }
        else if (playerHealth.currentHealth <= 500f)
        {
            spawnTime = 5f;
        }
        else
        {
            spawnTime = 10f;
        }
    }
}
