using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

    Vector3 V3;

    float TurnSpeed;

    float X;
    // Use this for initialization
    void Start()
    {
        //  Screen.lockCursor = true;
        TurnSpeed = 7f;
    }

    void OnMouseDown()
    {
        // Screen.lockCursor = true;
    }


    // Update is called once per frame
    void Update()
    {
        X = -Input.GetAxis("Mouse Y");

        // if(transform.rotation.eulerAngles.x+X <= 40f || transform.rotation.eulerAngles.x+X >= 320f)
        {
            // V3 = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);

            V3 = new Vector3(X, 0, 0);
            transform.Rotate(V3 * TurnSpeed);
        }



    }
}
