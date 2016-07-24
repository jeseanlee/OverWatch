using UnityEngine;
using System.Collections;

public class HpController : MonoBehaviour {
    public int count = 0;
    public int count_max = 0; // 딜레이 time 
    public bool wait = false; // 판단변수   
    public GameObject Item_hp;
    

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
            if (count > count_max)
            {
                Item_hp.SetActive(true);
                count = 0;
                wait = false;
            }
        }
    }
}
