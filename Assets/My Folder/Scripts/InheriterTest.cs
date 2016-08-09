using UnityEngine;
using System.Collections;

public class InheriterTest : InheritanceTest {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            //Debug.Log(test1);
            Debug.Log("Can't access Inherited Private Fields!");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(test2);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log(test3);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            FunctionTest();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            //ReturnTest();
            Debug.Log("Can't access Inherited Private Functions!");
        }
    }
}
