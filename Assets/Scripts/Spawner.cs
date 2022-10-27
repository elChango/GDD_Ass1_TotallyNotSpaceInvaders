using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int spwanRate = 2;
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spwanRate, spwanRate);
    }

    void SpawnEnemy()
    {
        //TODO: update coordinates
        Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(10.8f, Random.Range(-4.7f, 4.5f),0), Quaternion.identity);
    }
}
