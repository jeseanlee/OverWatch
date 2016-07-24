using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{
    void Start(){
        //iTween.MoveTo(gameObject,iTween.Hash("x", 10,"easeType", "easeInOutExpo","loopType", "pingPong","delay", 1));
        iTween.MoveTo(this.gameObject, iTween.Hash("y", 10.0f,"Math.easeOutCirc","loopType" ,"time", 20.0f, "delay", 0.5f));
    }
    //     //x좌표 2로 이동.
    // "x", 2  ,    

    ////easyType을 지정합니다. 오브젝트가 특정 방식으로 가속, 감속을 하도록합니다. 
    //"easeType", "easeInOutExpo",

    ////오브젝트가 왕복운동을 하도록 합니다. 
    //"loopType", "pingPong", 

    ////명령을 내리고 1초후부터 에니메이션을 시작합니다. 
    //"delay", 1

}

