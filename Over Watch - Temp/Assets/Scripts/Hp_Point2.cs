using UnityEngine;
using System.Collections;

public class Hp_Point2 : MonoBehaviour {
    public int hpup=100;
    public Player_Ctrl PC;
    public Player_Ctrl_Blue PCB;
    public HpController HC;

   

    void OnCollisionEnter(Collision collision)
    {
        //스크립트 변수     =       객체 이름                <사용중인 스크립트>    
        //Player_Ctrl PC = GameObject.Find("Player").GetComponent<Player_Ctrl>();
        //HpController HC = GameObject.Find("HpController2").GetComponent<HpController>();

        if (collision.gameObject.tag=="Player_Red")
        {
                Debug.Log("HP먹음2");
                PC.hp += hpup;              
                HC.wait = true;
                
                if (PC.Max_hp < PC.hp)
                {
                    PC.hp = PC.Max_hp;
                }
            PC.LifeBar.sliderValue = PC.hp / PC.Max_hp;
        }
        if (collision.gameObject.tag == "Player_Blue")
        {
            PCB.hp += hpup;
            HC.wait = true;
            if (PCB.Max_hp < PCB.hp)
            {
                PCB.hp = PCB.Max_hp;
            }
            PCB.LifeBar.sliderValue = PCB.hp / PCB.Max_hp;
        }
    }

}
