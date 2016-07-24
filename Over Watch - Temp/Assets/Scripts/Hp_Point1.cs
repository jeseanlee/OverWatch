using UnityEngine;
using System.Collections;

public class Hp_Point1 : MonoBehaviour {
    public int hpup = 100;

    public Player_Ctrl PC;
    public Player_Ctrl_Blue PCB;
    public HpController HC;
 

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player_Red")
        {
            Debug.Log("HP먹음1");
            PC.hp += hpup;
            HC.wait = true;
            if (PC.Max_hp < PC.hp)  
            {
                PC.hp = PC.Max_hp;
            }
            PC.LifeBar.sliderValue = PC.hp / PC.Max_hp;
        }
        if(collision.gameObject.tag == "Player_Blue")
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
