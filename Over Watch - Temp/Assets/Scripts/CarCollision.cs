using UnityEngine;
using System.Collections;
public enum CollisionState
{
    No_Collision,
    Blue_Collision,    
    Red_Collision,
    All_Collision
}
public class CarCollision : MonoBehaviour
{
    public CollisionState Col;
    public GameManager GM;

    void Start()
    {
        Col = CollisionState.No_Collision;
    }

    void OnTriggerEnter(Collider Get)
    {
        if (GM.GS == GameState.Red_First || GM.GS == GameState.Red_Second)
        {
            if (Get.GetComponent<Collider>().tag == "Player_Red" && Col == CollisionState.No_Collision)
            {
                Col = CollisionState.Red_Collision;
                GM.CS = CarState.Go;
            }
            else if (Get.GetComponent<Collider>().tag == "Player_Blue" && Col == CollisionState.No_Collision)
            {
                Col = CollisionState.Blue_Collision;
                GM.CS = CarState.Stop;
            }
            else if (Get.GetComponent<Collider>().tag == "Player_Blue" && Col == CollisionState.Red_Collision)
            {
                Col = CollisionState.All_Collision;
                GM.CS = CarState.Stop;
            }
            else if (Get.GetComponent<Collider>().tag == "Player_Red" && Col == CollisionState.Blue_Collision)
            {
                Col = CollisionState.All_Collision;
                GM.CS = CarState.Stop;
            }
        }
        else if (GM.GS == GameState.Blue_First || GM.GS == GameState.Blue_Second)
        {
            if (Get.GetComponent<Collider>().tag == "Player_Red" && Col == CollisionState.No_Collision)
            {
                Col = CollisionState.Red_Collision;
                GM.CS = CarState.Stop;
            }
            else if (Get.GetComponent<Collider>().tag == "Player_Blue" && Col == CollisionState.No_Collision)
            {
                Col = CollisionState.Blue_Collision;
                GM.CS = CarState.Go;
            }
            else if (Get.GetComponent<Collider>().tag == "Player_Blue" && Col == CollisionState.Red_Collision)
            {
                Col = CollisionState.All_Collision;
                GM.CS = CarState.Stop;
            }
            else if (Get.GetComponent<Collider>().tag == "Player_Red" && Col == CollisionState.Blue_Collision)
            {
                Col = CollisionState.All_Collision;
                GM.CS = CarState.Stop;
            }
        }
    }
    void OnTriggerExit(Collider Get)
    {
        if (GM.GS == GameState.Red_First || GM.GS == GameState.Red_Second)
        {
            if (Get.GetComponent<Collider>().tag == "Player_Red" && Col == CollisionState.All_Collision)
            {
                Col = CollisionState.Blue_Collision;
                GM.CS = CarState.Stop;
            }
            else if (Get.GetComponent<Collider>().tag == "Player_Blue" && Col == CollisionState.All_Collision)
            {
                Col = CollisionState.Red_Collision;
                GM.CS = CarState.Go;
            }
            else if (Get.GetComponent<Collider>().tag == "Player_Red" && Col == CollisionState.Red_Collision)
            {
                Col = CollisionState.No_Collision;
                GM.CS = CarState.Stop;
            }
            else if (Get.GetComponent<Collider>().tag == "Player_Blue" && Col == CollisionState.Blue_Collision)
            {
                Col = CollisionState.No_Collision;
                GM.CS = CarState.Stop;
            }
        }
        else if (GM.GS == GameState.Blue_First || GM.GS == GameState.Blue_Second)
        {
            if (Get.GetComponent<Collider>().tag == "Player_Red" && Col == CollisionState.All_Collision)
            {
                Col = CollisionState.Blue_Collision;
                GM.CS = CarState.Go;
            }
            else if (Get.GetComponent<Collider>().tag == "Player_Blue" && Col == CollisionState.All_Collision)
            {
                Col = CollisionState.Red_Collision;
                GM.CS = CarState.Stop;
            }
            else if (Get.GetComponent<Collider>().tag == "Player_Red" && Col == CollisionState.Red_Collision)
            {
                Col = CollisionState.No_Collision;
                GM.CS = CarState.Stop;
            }
            else if (Get.GetComponent<Collider>().tag == "Player_Blue" && Col == CollisionState.Blue_Collision)
            {
                Col = CollisionState.No_Collision;
                GM.CS = CarState.Stop;
            }
        }
   }
}
