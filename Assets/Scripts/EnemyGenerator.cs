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
    private float[] generatePositionY = { 3.01f, 1.37f, -0.29f, -2.06f };
    private float timerSpawn = 0f;
    private float timerRound = 0f;
    private List<EnemyListStruc> enemies = new List<EnemyListStruc>();
    private int currentRound = 1;
    private float[] differentsRespawnTime = { 10f, 9f, 8f, 7f, 6f };
    private int respawnTimeIndex = 0;

    public List<EnemyListStruc> enemiesLVL1 = new List<EnemyListStruc>();
    public float roundTime = 30f;
    public TextMeshProUGUI textRound;

    void Start()
    {
        this.enemies.AddRange(enemiesLVL1);
        InstanciateRandomEnemyList();
        textRound.text = "Ronda: " + this.currentRound;
        respawnTimeIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.timerSpawn += Time.deltaTime;
        this.timerRound += Time.deltaTime;
        if (timerSpawn > differentsRespawnTime[respawnTimeIndex])
        {
            timerSpawn -= differentsRespawnTime[respawnTimeIndex]; //This is so it doesn't lose a few miliseconds every spawn
            InstanciateRandomEnemyList();
        }
        if (timerRound > roundTime)
        {
            if (currentRound % 5 == 0)
            {
                respawnTimeIndex = 0;
            }
            else
            {
                respawnTimeIndex += 1;
            }
            timerRound -= roundTime;
            this.currentRound += 1;
            textRound.text = "Ronda: " + this.currentRound;
            Debug.Log(differentsRespawnTime[respawnTimeIndex]);
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
