using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRange = 5f;
    [SerializeField] private int poolSize = 10;
    private Queue<GameObject> objectPool = new Queue<GameObject>();

    void Start()
    {
        GameObject objectPrefab = Resources.Load<GameObject>("Enemy");
        if(objectPrefab == null)
        {
            print("Prefab not found");
            return;
        }

        // Instanziierung eines Pools
        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObjectFromPool();
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

    public void SpawnObjectFromPool()
    {
        if (objectPool.Count > 0)
        {
            GameObject obj = objectPool.Dequeue();
            ActivateObj(obj);
        }
        else
        {
            GameObject objectPrefab = Resources.Load<GameObject>("Enemy");
            //wenn der pool leer ist
            print("Pool is empty, Instantiating new object");
            GameObject obj = Instantiate(objectPrefab);
            ActivateObj(obj);

        }
    }

    private void ActivateObj(GameObject obj)
    {
        obj.SetActive(true);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange));
        obj.transform.position = spawnPosition;
        obj.transform.rotation = Quaternion.identity;
    }
}
