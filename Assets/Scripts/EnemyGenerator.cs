using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Collections;

[Serializable]
public class EnemyListStruc
{
    public List<GameObject> EnemyList;
}

public class EnemyGenerator : MonoBehaviour
{

    private float generatePositionX = 19.30f;
    private float[] generatePositionY = { 2.51f, 0.86f, -0.81f, -2.47f };
    private float timerSpawn = 0f;
    private float timerRound = 0f;
    private List<EnemyListStruc> enemies = new List<EnemyListStruc>();
    private int currentRound = 1;
    private float minRespawnTime = 3f;
    private float respawnTime = 15f;

    public List<EnemyListStruc> enemiesLVL1 = new List<EnemyListStruc>();
    public float roundTime = 20f;
    public TextMeshProUGUI textRound;

    void Start()
    {
        this.enemies.AddRange(enemiesLVL1);
        InstanciateRandomEnemyList();
        textRound.text = "Ronda: " + this.currentRound;
    }

    // Update is called once per frame
    void Update()
    {
        this.timerSpawn += Time.deltaTime;
        this.timerRound += Time.deltaTime;
        if (timerSpawn > respawnTime)
        {
            timerSpawn -= respawnTime;
            InstanciateRandomEnemyList();
        }
        if (timerRound > roundTime)
        {
            timerRound -= roundTime;
            this.currentRound += 1;
            textRound.text = "Ronda: " + this.currentRound;
            respawnTime -= 0.5f;
            if (respawnTime < minRespawnTime)
            {
                respawnTime = minRespawnTime;
            }
        }
    }

    void InstanciateRandomEnemyList()
    {
        List<GameObject> enemiesItems = this.enemies[GetRandomEnemyIndex()].EnemyList;
        float seconds = 0;
        foreach (GameObject item in enemiesItems)
        {
            StartCoroutine(InstantiatePrefabWithDelay(item, seconds));
            seconds += 1.3f;
        }
    }

    private int GetRandomEnemyIndex()
    {
        int index = UnityEngine.Random.Range(0, this.enemies.Count);
        return index;
    }

    private float GetRandomPosition()
    {
        int index = UnityEngine.Random.Range(0, this.generatePositionY.Length);
        return this.generatePositionY[index];
    }

    IEnumerator InstantiatePrefabWithDelay(GameObject enemyItem,float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Instantiate(enemyItem, new Vector3(generatePositionX, this.GetRandomPosition(), 0f), Quaternion.identity);
    }
}
