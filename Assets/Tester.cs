using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : TestManager {

    public void Test1()
    {
        AssertEquals(10, 10);
    }

    public void Test2()
    {
        AssertTrue(false);
    }

    public void Test3()
    {
        AssertNotNull(new int[0]);
    }
	
}
