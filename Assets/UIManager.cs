using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Goal goal1;
    public Goal goal2;
    public Text[] pointTexts = new Text[2];
    public Rigidbody2D ball;
    [HideInInspector] public int[] points = new int[2];

	// Use this for initialization
	void Start () {
        goal1.point = Point;
        goal2.point = Point;
        StartCoroutine(LateStart());
	}

    IEnumerator LateStart() {
        yield return null;
        new Tester(this);
    }

    public void Point(int player)
    {
        pointTexts[player].text = (++points[player]).ToString();
        Reset();
    }

    public void Reset()
    {
        ball.velocity = new Vector2(Random.value < 0.5f ? -2 : 2, (Random.value * 2 - 1) * 2);
        ball.transform.localPosition = Vector3.zero;
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
