using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Queue<GameObject> Enemys = new Queue<GameObject>();


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Enemys.Count > 0)
            {
                GameObject nextEnemy = Enemys.Dequeue();
                ColorChange(nextEnemy);
                Enemys.Enqueue(nextEnemy);
            }
        }
    }

    private void ColorChange(GameObject enemy)
    {
        enemy.gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
}
