using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_new : MonoBehaviour
{

    public static Queue<GameObject> Enemys = new Queue<GameObject>();


    void Start()
    {
        
        Enemys.Enqueue(gameObject);

        print($"Anzahl der momentanen Enemys: {Enemys.Count}");
    }

    public static void ColorChange(GameObject enemy)
    {
        enemy.gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
}
