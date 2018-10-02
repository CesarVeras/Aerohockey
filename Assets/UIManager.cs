using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Goal goal1;
    public Goal goal2;
    public Text[] pointTexts = new Text[2];
    public Rigidbody2D ball;
    int[] points = new int[2];

	// Use this for initialization
	void Start () {
        goal1.point = Point;
        goal2.point = Point;
	}

    void Point(int player)
    {

        new Tester();
        pointTexts[player].text = (++points[player]).ToString();
        Reset();
    }

    private void Reset()
    {
        ball.velocity = new Vector2(Random.value < 0.5f ? -2 : 2, (Random.value * 2 - 1) * 2);
        ball.gameObject.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update () {
        // RESET MECHANIC
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.KeypadEnter))
        {
            Reset();
        }
    }
}
