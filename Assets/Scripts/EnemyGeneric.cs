using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGeneric : MonoBehaviour
{   
    
    private Rigidbody2D rigidbody2d;
    public float velocity;
    public float speedMultiplier = 1f;
    private int currentHP;
    public int maxHP = 100;
    public float debuffSpeed = 0f;
    // Start is called before the first frame update
    void Start(){
        this.rigidbody2d = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update(){
        this.rigidbody2d.velocity = Vector3.left * this.velocity * (this.speedMultiplier - debuffSpeed);
        if (this.transform.position.x < GameUtils.basePositionX){
            SceneManager.LoadScene("Lose", LoadSceneMode.Single);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        GameObject colliderObject = other.gameObject;
        if (colliderObject.CompareTag("Projectile")){
            projectileBehaviour projectileBehaviourComponent = colliderObject.GetComponent<projectileBehaviour>();
            projectileBehaviourComponent.penetrationCount -= 1;
            if (projectileBehaviourComponent.debuffSpeed > debuffSpeed)
            {
                debuffSpeed = projectileBehaviourComponent.debuffSpeed;
            }
            this.currentHP -= projectileBehaviourComponent.damage;
            if(projectileBehaviourComponent.penetrationCount < 0){
                Destroy(colliderObject);
            }
            if (currentHP <= 0){
                Destroy(this.gameObject);
            }
        }
        if (colliderObject.gameObject.CompareTag("summoned")){
            Destroy(colliderObject.gameObject);
        }
    }
}