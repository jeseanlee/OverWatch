using UnityEngine;
using System.Collections;

public enum GameState
{
    //시작
    GameState_Start,
    //공격 1단계 돌파
    Red_First,
    //공격 최종 돌파
    Red_Second,
    //중간 공수 체인지
    GameState_Change,
    //방어 1단계 돌파
    Blue_First,
    //방어 최종 돌파
    Blue_Second,
    //종료    
    GameState_End
}
public enum CarState
{
    Go,
    Stop
}

public class GameManager : MonoBehaviour{
    public GameState GS;
    public CarState CS;

    public GameObject Red;//포인트 변수
    public GameObject Blue;                      
                          
    // Use this for initialization
    void Start (){
        GS = GameState.Red_First;
        CS = CarState.Stop;            
    }	
	// Update is called once per frame
	void Update (){
	    if(GS== GameState.Blue_First)
        {
            Red.SetActive(false);
            Blue.SetActive(true);
        }
        else if (GS == GameState.GameState_End)
        {
            Blue.SetActive(false);
        }
    }
}
