using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public Vector2 spawnRange;
    // Update is called once per frame
    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(spawnRange[0], spawnRange[1]), enemy.transform.position.y, Random.Range(spawnRange[0], spawnRange[1]));
        Instantiate(enemy, spawnPosition, enemy.transform.rotation);
    }
}
