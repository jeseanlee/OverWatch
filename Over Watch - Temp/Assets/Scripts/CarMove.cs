using UnityEngine;
using System.Collections;


public class CarMove : MonoBehaviour
{
    public GameManager GM;

    void Update()
    {
        if (GM.GS == GameState.Red_First && GM.CS == CarState.Go)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("z", -30f, "Math.easeOutCirc", "loopType",
                                                       "time", 5f, "delay", 0.5f,
                                                       "oncomplete", "Red_First_End"));
        }       
        else if(GM.GS == GameState.Red_Second && GM.CS == CarState.Go)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("z", -10f, "Math.easeOutCirc", "loopType",
                                                       "time", 5f, "delay", 0.5f,
                                                       "oncomplete", "Red_Second_End"));    
        }
        else if (GM.GS == GameState.Blue_First && GM.CS == CarState.Go)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("z", -30f, "Math.easeOutCirc", "loopType",
                                                       "time", 5f, "delay", 0.5f,
                                                       "oncomplete", "Blue_First_End"));
        }
        else if (GM.GS == GameState.Blue_Second && GM.CS == CarState.Go)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("z", -50f, "Math.easeOutCirc", "loopType",
                                                       "time", 5f, "delay", 0.5f,
                                                       "oncomplete", "Blue_Second_End"));
        }
        else
        {
            iTween.Stop(this.gameObject);
        }
    }
    
    public void Red_First_End()
    {
        GM.GS = GameState.Red_Second;
        Debug.Log("Red_First_End");
    }
    public void Red_Second_End()
    {
        GM.GS = GameState.Blue_First;
        Debug.Log("Red_Second_End");
    }
    public void Blue_First_End()
    {
        GM.GS = GameState.Blue_Second;
        Debug.Log("Blue_First_End");
    }
    public void Blue_Second_End()
    {
        GM.GS = GameState.GameState_End;
        Debug.Log("Blue_Second_End");
    }
}