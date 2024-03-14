using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner_old : MonoBehaviour
{
    [SerializeField] private float spawnRange = 5f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPrefab();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Enemy_new.Enemys.Count > 0)
            {
                GameObject nextEnemy = Enemy_new.Enemys.Dequeue();
                Enemy_new.ColorChange(nextEnemy);
                Enemy_new.Enemys.Enqueue(nextEnemy);
            }
        }
    }

    private void SpawnPrefab()
    {
        GameObject objectPrefab = Resources.Load<GameObject>("Enemy");
        if(objectPrefab != null)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange));
            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            print("Prefab not found");
        }
    }
}
