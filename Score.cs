using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text TopScore;
    private Text txt;
    private bool GameStart;

    void Start()
    {
        TopScore.text = "TOP: " + PlayerPrefs.GetInt("TopScore").ToString();
        txt = GetComponent<Text>();
        CubeJump.CountBlocks = 0;
    }

    void Update()
    {
        if (txt.text == "0") //Если переменная текст вмещает в себя строку 0, значит, игра уже началась.
        {
            GameStart = true;
        }
        if (GameStart == true)
        {
            txt.text = CubeJump.CountBlocks.ToString(); //Вывод кол-ва блоков из CubeJump.
            if (PlayerPrefs.GetInt("TopScore") < CubeJump.CountBlocks)
            {
                PlayerPrefs.SetInt("TopScore", CubeJump.CountBlocks); //Если лучший счет меньше нынешнего, записать вместо него нынешний.
                TopScore.text = "TOP: " + PlayerPrefs.GetInt("TopScore").ToString();
            }
        }
    }
}
