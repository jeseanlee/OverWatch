using UnityEngine;
using System.Collections;

public class Player_Collider : MonoBehaviour
{
    private int count = 0;
    private int count2 = 0;
    private static bool wait = false;
    private static bool wait2 = false;
    public GameObject Item_hp;
    public GameObject Item_hp2;
    public int hpup = 0;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (wait == true)
        {
            count++;          
            Item_hp.SetActive(false);
            if (count > 400)
            {
                Item_hp.SetActive(true);
                count = 0;
                wait = false;

            }
        }
        if (wait2 == true)
        {

            count2++;
            Item_hp2.SetActive(false);
            if (count2 > 400)
            {
                Item_hp2.SetActive(true);
                count2 = 0;
                wait2 = false;
            }
        }
    }

    void OnTriggerEnter(Collider Get)
    {
        //내가사용할 타입변수 =       객체 이름                스크립트   
        //Item_hp Ih = GameObject.Find("Item_hp").GetComponent<Item_hp>();
        //Item_hp2 Ih2 = GameObject.Find("Item_hp2").GetComponent<Item_hp2>();
        Player_Ctrl PC = GameObject.Find("Player").GetComponent<Player_Ctrl>();

        if (Get.GetComponent<Collider>().tag == "Item")
        {
            //조건문 + 넘어가지않게 해주기!            
            if (wait == false)
            {
                //플레이어HP 를 가져오고 하트의 HP를 더해줘라!
                PC.hp += hpup;
                wait = true;
                if (PC.Max_hp < PC.hp)
                {
                    PC.hp = PC.Max_hp;
                }
            }
            PC.LifeBar.sliderValue = PC.hp / PC.Max_hp;
        }
        else if (Get.GetComponent<Collider>().tag == "Item2")
        {
            //조건문 + 넘어가지않게 해주기!  
            if (wait2 == false)
            {
                //플레이어HP 를 가져오고 하트의 HP를 더해줘라!
                PC.hp += hpup;
                wait2 = true;
                if (PC.Max_hp < PC.hp)
                {
                    PC.hp = PC.Max_hp;
                }
            }
            PC.LifeBar.sliderValue = PC.hp / PC.Max_hp;
        }
    }
}

