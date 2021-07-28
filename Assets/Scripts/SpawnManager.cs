using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public Vector2 spawnRange;
    private int m_EnemyCount;
    private int m_SpawnCount = 1;
    // Update is called once per frame
    void Start()
    {
        SpawnEnemy(m_SpawnCount);
    }

    void Update()
    {
        m_EnemyCount = FindObjectsOfType<EnemyController>().Length;

        if (m_EnemyCount == 0)
        {
            m_SpawnCount++;
            SpawnEnemy(m_SpawnCount);
        }
    }

    void SpawnEnemy(int numberOfSpawn)
    {
        for (int i = 0; i < m_SpawnCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(spawnRange[0], spawnRange[1]), enemy.transform.position.y, Random.Range(spawnRange[0], spawnRange[1]));
            Instantiate(enemy, spawnPosition, enemy.transform.rotation);
        }
    }
}
