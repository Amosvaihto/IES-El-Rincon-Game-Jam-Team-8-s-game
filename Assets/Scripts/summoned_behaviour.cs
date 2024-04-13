using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summoned_behaivour : MonoBehaviour
{
    public GameObject projectilePrefab;
    private float timerSpawn = 0f;
    public float respawnTime = 2f;
    public float projectileSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        projectilePrefab.GetComponent<projectile_behaviour>().projectileSpeed = projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        this.timerSpawn += Time.deltaTime;
        if (timerSpawn > respawnTime)
        {
            timerSpawn -= respawnTime;
            GameObject leprojectile = Instantiate(this.projectilePrefab, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity);
            leprojectile.GetComponent<projectile_behaviour>().projectileSpeed = projectileSpeed;
        }
    }
}
