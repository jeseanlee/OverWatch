using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour
{

    public UILabel NameLabel;
    public GameObject BestData;
    public UILabel BestUserData_Label;

    void GoPlay()
    {
        if (NameLabel.text == "Type your name")
        {
            return;
        }
        //UserName 이라는 String 타입의 데이터베이스에 NameLabel에 있는 text 값을 저장하기.
        PlayerPrefs.SetString("UserName", NameLabel.text);
        //씬 이동하기.
        Application.LoadLevel("MainPlay");
    }

    void BestScore()
    {
        BestUserData_Label.text = string.Format("{0}:{1:N0}", PlayerPrefs.GetString("BestPlayer"), PlayerPrefs.GetFloat("BestScore"));

        if (BestUserData_Label.text != ":0")
        {
            BestData.SetActive(true);
        }
    }

    void Quit()
    {
        Application.Quit();
    }
}
