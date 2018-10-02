using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour {

    Rigidbody2D rb;
    public float speed = 2;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        var left = Random.value < 0.5f;
        var vel = new Vector2(left ? -2 : 2, (Random.value * 2 - 1) * 2);
        rb.velocity = vel.normalized * speed;
        print(vel);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var vel = rb.velocity;
        vel *= 0.999f;
        rb.velocity = vel;
	}
}
