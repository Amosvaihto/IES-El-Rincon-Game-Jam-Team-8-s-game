using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonedBehaviour : MonoBehaviour
{   
    private float dTimer = 0;
    public int damage = 25;
    public float timePerHit = 2f;
    public float manaCost = 25f;
    public float despawnTime = 15f;

    void Update(){
        this.dTimer += Time.deltaTime;
        if (dTimer > despawnTime){
            Destroy(gameObject);
        }
    }
}
