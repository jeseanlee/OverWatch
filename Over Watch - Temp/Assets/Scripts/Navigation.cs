using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour
{
    public float delaytime = 0;

    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("New Path 1"), "time", 20.0f, "loopType", "loop", "delay", delaytime));
    }   
}
