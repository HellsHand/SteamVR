using UnityEngine;
using System.Collections;

public class InheritanceTest : MonoBehaviour {

    private int test1 = 1;

    public bool test2 = true;

    protected string test3 = "String Test";

	public void FunctionTest()
    {
        Debug.Log("test4");
    }

    private int ReturnTest()
    {
        return 5;
    }
}
