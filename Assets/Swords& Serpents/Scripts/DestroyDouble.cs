using UnityEngine;
using System.Collections;

public class DestroyDouble : MonoBehaviour {
    int test = 3;
    void Start()
    {
        string text = ( test == 5 ) ? "Correct":"False";
        Debug.Log(text);
        GameObject duplicate = ObjectsAtVector();
        if (duplicate != null)
        {
            Destroy(duplicate);
        }
    }

    //Works but has to be a faster way!
    GameObject ObjectsAtVector()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag(gameObject.tag)) {
            if(this.transform.position == obj.transform.position && obj.transform != this.transform)
            {
                return obj;
            }
        }
        return null;
    }
}
