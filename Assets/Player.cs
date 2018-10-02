using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public bool wasd = true;
    Rigidbody2D rb;
    public float speed = 2f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.zero;
        if (wasd)
        {
            if (Input.GetKey(KeyCode.W))
            {
                dir.y++;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y--;
            }
            else
            {
                dir.y = 0;
            }

            if (Input.GetKey(KeyCode.D))
            {
                dir.x++;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                dir.x--;
            }
            else
            {
                dir.x = 0;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                dir.y++;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                dir.y--;
            }
            else
            {
                dir.y = 0;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                dir.x++;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                dir.x--;
            }
            else
            {
                dir.x = 0;
            }
        }
        rb.velocity = dir * speed;
    }
}