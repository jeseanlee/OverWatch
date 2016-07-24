using UnityEngine;
using System.Collections;

public class Navigation2 : MonoBehaviour {

    // Use this for initialization
    public float delaytime = 0;

    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("New Path 2"), "time", 20.0f, "loopType", "loop", "delay", delaytime));
    }

    // Update is called once per frame
    void Update () {
	
	}
}


