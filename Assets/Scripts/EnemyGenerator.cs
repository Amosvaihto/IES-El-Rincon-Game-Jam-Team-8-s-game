using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyGenerator : MonoBehaviour
{

    private float generatePositionX = 10;
    private float[] generatePositionY = { 2.1f, 0.16f, -1.67f, -3.59f };
    private List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> enemiesLVL1 = new List<GameObject>();
    private float timerSpawn = 0f;
    public float respawnTime = 4f;

    void Start()
    {
        this.enemies.AddRange(enemiesLVL1);
    }

    // Update is called once per frame
    void Update()
    {
        this.timerSpawn += Time.deltaTime;
        if (timerSpawn > respawnTime)
        {
            timerSpawn = 0;
            Instantiate(this.GetRandomEnemy(), new Vector3(generatePositionX, this.GetRandomPosition(), 0f), Quaternion.identity);
        }
    }

    private GameObject GetRandomEnemy()
    {
        int index = UnityEngine.Random.Range(0, this.enemies.Count);
        return this.enemies[index];
    }

    private float GetRandomPosition()
    {
        int index = UnityEngine.Random.Range(0, this.generatePositionY.Length);
        return this.generatePositionY[index];
    }
}
