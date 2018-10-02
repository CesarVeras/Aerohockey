using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Goal : MonoBehaviour {

    public delegate void Point(int player);
    public Point point;
    public int player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Disc")
        {
            point(player);
        }
    }

}
