using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyManager enemyManager;

    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyManager.Enemys.Enqueue(gameObject);

        print($"Anzahl der momentanen Enemys: {enemyManager.Enemys.Count}");
    }
}
