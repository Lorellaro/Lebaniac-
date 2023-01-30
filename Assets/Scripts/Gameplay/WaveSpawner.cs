using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float timeBtwSpawns = 5f;
    [SerializeField] float maxNumOfSpawns = 15f;
    [SerializeField] Transform[] spawnPos;

    float currentTimeBtwSpawn = 0f;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag(enemy.tag).Length + 1 > maxNumOfSpawns) { return; }

        if(currentTimeBtwSpawn > 0)
        {
            currentTimeBtwSpawn -= Time.deltaTime;
        }
        else
        {
            Instantiate(enemy, spawnPos[Random.Range(0, spawnPos.Length)]);
            currentTimeBtwSpawn = timeBtwSpawns;
        }
    }
}
