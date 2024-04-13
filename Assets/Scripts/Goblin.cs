using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{

    Rigidbody2D rigidbody2d;
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        this.rigidbody2d.velocity = Vector3.left * this.velocity;

    }
}
