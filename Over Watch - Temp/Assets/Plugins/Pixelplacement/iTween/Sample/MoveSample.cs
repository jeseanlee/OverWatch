using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{
    void Start(){
        //iTween.MoveTo(gameObject,iTween.Hash("x", 10,"easeType", "easeInOutExpo","loopType", "pingPong","delay", 1));
        iTween.MoveTo(this.gameObject, iTween.Hash("y", 10.0f,"Math.easeOutCirc","loopType" ,"time", 20.0f, "delay", 0.5f));
    }
    //     //x��ǥ 2�� �̵�.
    // "x", 2  ,    

    ////easyType�� �����մϴ�. ������Ʈ�� Ư�� ������� ����, ������ �ϵ����մϴ�. 
    //"easeType", "easeInOutExpo",

    ////������Ʈ�� �պ���� �ϵ��� �մϴ�. 
    //"loopType", "pingPong", 

    ////����� ������ 1���ĺ��� ���ϸ��̼��� �����մϴ�. 
    //"delay", 1

}

