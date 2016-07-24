using UnityEngine;
using System.Collections;

public class PlayManager : MonoBehaviour
{

    public bool PlayEnd;
    public float Limit_Time = 60f;
    public int Enemy_Count = 10;

    public UILabel TimeLabel;
    public UILabel EnemyLabel;
    public GameObject FinalGUI;
    public UILabel FinalMessage;
    public UILabel FinalScoreLabel;

    public UILabel PlayerName;
    public UILabel GunTan;
    public int GunTan_Count = 100;
    public int GunTan_Count1 = 20;
    public int GunTan_Count2 = 300;

    void Start()
    {
        GunTan_Count = 100;
        //PlayerManager를 찾아서 PM이라는 이름으로 가져와 함수 실행시키기.
        GunTan.text = string.Format("GunTan : {0}", GunTan_Count);
        EnemyLabel.text = string.Format("Enemy : {0}", Enemy_Count);
        TimeLabel.text = string.Format("Time : {0:N2}", Limit_Time);

        PlayerName.text = PlayerPrefs.GetString("UserName");
    }

    void Update()
    {
     
        if (PlayEnd != true)
        {
            Player_Ctrl PM = GameObject.FindWithTag("Player_Red").GetComponent<Player_Ctrl>();
            if (PM.PI == PlayItem.Weapon1)
                GunTan.text = string.Format("GunTan : {0}", GunTan_Count);
            else if (PM.PI == PlayItem.Weapon2)
                GunTan.text = string.Format("GunTan : {0}", GunTan_Count1);
            else if (PM.PI == PlayItem.Weapon3)
                GunTan.text = string.Format("Axe", 0);
            else if (PM.PI == PlayItem.Weapon4)
                GunTan.text = string.Format("GunTan : {0}", GunTan_Count2);


            if (Limit_Time > 0)
            {
                Limit_Time -= Time.deltaTime;
                TimeLabel.text = string.Format("Time:{0:N2}", Limit_Time);
            }
            else
            {
                GameOver();
            }
        }
    }

    public void Clear()
    {
        if (PlayEnd != true)
        {
            Time.timeScale = 0;
            PlayEnd = true;
            FinalMessage.text = "Clear!!";

            //플레이어를 찾아서 Player_Ctrl을 PC라는 이름으로 가져오기.
            Player_Ctrl PC = GameObject.Find("Player_Red").GetComponent<Player_Ctrl>();

            //최종점수 공식 : 클리어점수 + 남은시간 보너스 + 남은 HP 보너스.
            float score = 12345f + Limit_Time * 123f + PC.hp * 123f;
            FinalScoreLabel.text = string.Format("{0:N0}", score);

            //c최종결과화면 GUI 활성화 시키기.
            FinalGUI.SetActive(true);

            BestCheck(score);

        }
    }

    public void GameOver()
    {
        if (PlayEnd != true)
        {
            Time.timeScale = 0;
            PlayEnd = true;
            FinalMessage.text = "Fail...";
            float score = 1234f + Enemy_Count * 123f;
            FinalScoreLabel.text = string.Format("{0:N0}", score);
            FinalGUI.SetActive(true);

            BestCheck(score);
        }

        //플레이어를 찾아서 Player_Ctrl을 PC라는 이름으로 가져오기.
        Player_Ctrl PC = GameObject.Find("Player").GetComponent<Player_Ctrl>();
        PC.PS = PlayerState.Dead;
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("MainPlay");
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("Title");
    }

    public void EnemyDie()
    {
        Enemy_Count -= 1;
        EnemyLabel.text = string.Format("Enemy : {0}", Enemy_Count);
        if (Enemy_Count <= 0)
        {
            Clear();
        }
    }

    public void MinusGun()
    {
        Player_Ctrl PM = GameObject.FindWithTag("Player_Red").GetComponent<Player_Ctrl>();
        if (PM.PI == PlayItem.Weapon1)
        {
            if (GunTan_Count > 0)
                GunTan_Count -= 1;
            GunTan.text = string.Format("GunTan : {0}", GunTan_Count);
        }
        else if (PM.PI == PlayItem.Weapon2)

        {
            if (GunTan_Count1 > 0)
                GunTan_Count1 -= 1;
            GunTan.text = string.Format("GunTan : {0}", GunTan_Count1);
        }

        else if (PM.PI == PlayItem.Weapon3)

        {

            GunTan.text = string.Format("  :{0}");
        }

        else if (PM.PI == PlayItem.Weapon4)

        {
            if (GunTan_Count2 > 0)
                GunTan_Count2 -= 1;
            GunTan.text = string.Format("GunTan : {0}", GunTan_Count2);
        }





        if (GunTan_Count <= 0)
        {
           // Clear();
        }
    }

    public void PlusGun()
    {
     
        Player_Ctrl PM = GameObject.FindWithTag("Player_Red").GetComponent<Player_Ctrl>();
        if (PM.PI == PlayItem.Weapon1)
        {
         
            if (GunTan_Count < 100)
                GunTan_Count = 100;
            GunTan.text = string.Format("GunTan : {0}", GunTan_Count);
        }
        else if (PM.PI == PlayItem.Weapon2)

        {
            if (GunTan_Count1 < 20)
                GunTan_Count1 = 20;
            GunTan.text = string.Format("GunTan : {0}", GunTan_Count1);
        }
        else if (PM.PI == PlayItem.Weapon4)

        {
            if (GunTan_Count1 < 300)
                GunTan_Count1 = 300;
            GunTan.text = string.Format("GunTan : {0}", GunTan_Count2);
        }

    }

    public void BestCheck(float score)
    {
        //저장되어 있는 베스트 스코어를 가져온다.
        float BestScore = PlayerPrefs.GetFloat("BestScore");

        //지금의 점수가 베스트스코어보다 큰 경우 덮어쓴다.
        if (score > BestScore)
        {
            PlayerPrefs.SetFloat("BestScore", score);
            PlayerPrefs.SetString("BestPlayer", PlayerPrefs.GetString("UserName"));
        }

    }


}
