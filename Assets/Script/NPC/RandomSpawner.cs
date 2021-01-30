using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    public float startTime = 2f;
    public float sequenceTime = 3f;

    private List<Vector3> enemyPositions = new List<Vector3>();

    void Start() {
        StartCoroutine(WaitBeforeBegin());
    }

    private void ShowEnemy()
    {
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        Vector3 pointCoordinates = spawnPoints[randSpawnPoint].position;

        if (!VerifyEnemyPosition(pointCoordinates))
            Instantiate(enemyPrefab, pointCoordinates, transform.rotation);

        enemyPositions.Add(pointCoordinates);
    }

    private bool VerifyEnemyPosition(Vector3 coordinates)
    {
        return enemyPositions.Exists(position => position == coordinates);
    }

    private void RenderSprite()
    {
        if(!enemyPrefab.activeInHierarchy)
            enemyPrefab.SetActive(true);
    }

    IEnumerator WaitBeforeBegin()
    {
        yield return new WaitForSeconds(startTime);
        
        RenderSprite();
        InvokeRepeating("ShowEnemy", startTime, sequenceTime);
    }
}
