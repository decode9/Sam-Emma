using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    private List<Vector3> enemyPositions = new List<Vector3>();

    void Start() {
        InvokeRepeating("ShowEnemy", 2f, 3f);
    }

    private void ShowEnemy()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        Vector3 pointCoordinates = spawnPoints[randSpawnPoint].position;

        if (!verifyEnemyPosition(pointCoordinates))
            Instantiate(enemyPrefabs[randEnemy], pointCoordinates, transform.rotation);

        enemyPositions.Add(pointCoordinates);
    }

    private bool verifyEnemyPosition(Vector3 coordinates)
    {
        return enemyPositions.Exists(position => position == coordinates);
    }
}
