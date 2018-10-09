using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : TestManager {

    private UIManager manager;

    public Tester(UIManager man) {
        Debug.Log(man);
        manager = man;
        BeginTests();
    }

    public void TestPoint() {
        Debug.Log(manager);
        AssertEquals(manager.points[0], 0);
        AssertEquals(manager.points[1], 0);

        manager.Point(0);
        AssertEquals(manager.points[0], 1);
        AssertEquals(manager.points[1], 0);

        manager.Point(1);
        AssertEquals(manager.points[0], 1);
        AssertEquals(manager.points[1], 1);

        manager.points = new int[] { 0, 0 };
    }

    public void TestReset() {
        var ball = manager.ball;
        ball.velocity = Vector2.zero;
        ball.transform.localPosition = Random.insideUnitCircle * Random.Range(1, 10);
        manager.Reset();
        AssertNotEquals(ball.velocity, Vector2.zero);
        AssertEquals(ball.transform.localPosition, Vector3.zero);
    }

    public bool V3Equal(Vector3 a, Vector3 b) {
        return Vector3.SqrMagnitude(a - b) < 0.0001;
    }
}
