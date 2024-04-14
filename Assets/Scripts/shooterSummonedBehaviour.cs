using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shooterSummonedBehaviour : MonoBehaviour
{
    private float timePerProjectile;
    private int damage;
    private float pTimer = 0f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float projectileSizeX = 0.2f;
    public float projectileSizeY = 0.2f;
    public int penetrationCount = 0;
    public float debuffSpeed = 0f;

    // Start is called before the first frame update
    void Start(){
        timePerProjectile = this.gameObject.GetComponent<summonedBehaviour>().timePerHit;
        damage = this.gameObject.GetComponent<summonedBehaviour>().damage;
    }

    // Update is called once per frame
    void Update()
    {
        this.pTimer += Time.deltaTime;
        if (pTimer > timePerProjectile){
            pTimer -= timePerProjectile;
            GameObject leprojectile = Instantiate(this.projectilePrefab, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity);
            leprojectile.GetComponent<projectileBehaviour>().projectileSpeed = projectileSpeed;
            leprojectile.GetComponent<projectileBehaviour>().damage = damage;
            leprojectile.transform.localScale = new Vector3(projectileSizeX, projectileSizeY, 1f);
            leprojectile.GetComponent<projectileBehaviour>().penetrationCount = penetrationCount;
            leprojectile.GetComponent<projectileBehaviour>().debuffSpeed = debuffSpeed;
        }





        
    }
}
    


