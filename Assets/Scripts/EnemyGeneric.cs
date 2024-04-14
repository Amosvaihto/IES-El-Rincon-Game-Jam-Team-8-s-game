using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGeneric : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public float velocity;
    public float speedMultiplier = 1f;
    public int HP = 100;

    // Start is called before the first frame update
    void Start(){
        this.rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        this.rigidbody2d.velocity = Vector3.left * this.velocity * this.speedMultiplier;
        if (this.transform.position.x < GameUtils.basePositionX){
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        GameObject colliderObject = other.gameObject;
        if (colliderObject.CompareTag("Projectile")){
            projectileBehaviour projectileBehaviourComponent = colliderObject.GetComponent<projectileBehaviour>();
            projectileBehaviourComponent.penetrationCount -= 1;
            this.HP -= projectileBehaviourComponent.damage;
            if(projectileBehaviourComponent.penetrationCount < 0){
                Destroy(colliderObject);
            }
            if (HP <= 0){
                Destroy(this.gameObject);
            }
        }
        if (colliderObject.gameObject.CompareTag("summoned")){
            Destroy(colliderObject.gameObject);
        }
    }
}