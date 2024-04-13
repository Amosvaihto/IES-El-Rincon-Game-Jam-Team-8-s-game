using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_behaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float projectileSpeed = 2f;

    void Awake(){
        rb = this.gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
    }
    void Start()
    {
        rb.angularDrag = 0;
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(projectileSpeed, 0.0f);
    }
}
