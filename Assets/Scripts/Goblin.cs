using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goblin : MonoBehaviour
{

    Rigidbody2D rigidbody2d;
    public float velocity;

    public int HP = 100;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.rigidbody2d.velocity = Vector3.left * this.velocity;
        if (this.transform.position.x < GameUtils.basePositionX)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        GameObject colliderObject = other.gameObject;
        if (colliderObject.CompareTag("Projectile")){
            Debug.Log("Duele vivir");
            this.HP -= colliderObject.GetComponent<projectileBehaviour>().damage;
            Destroy(colliderObject);
            if (HP <= 0){
                Destroy(gameObject);
            }
        }
    }
}
