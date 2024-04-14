using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float projectileSpeed = 2f;
    public int damage = 25;
    public int penetrationCount = 0;
    public float debuffSpeed = 0f;

    void Awake(){
        rb = this.gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
    }
    void Start()
    {
        rb.angularDrag = 0;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(projectileSpeed, 0.0f);
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
