using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject EnemyPrefab;
    public float SpawnRate = 10.0f;

    float SpawnCountDown = 0.0f;
    
    void Start()
    {
    }

    void Update () {
        SpawnCountDown -= Time.deltaTime;
        if (SpawnCountDown < 0.0f)
        {
            SpawnCountDown += SpawnRate;
            Spawn();
        }
	}

    void Spawn()
    {
        GameObject enemy = GameObject.Instantiate(EnemyPrefab);
        enemy.transform.parent = transform;
    }
}
