using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountStars : MonoBehaviour
{
    private Text txt;
    public Text Stars;

    void Update()
    {
        txt = GetComponent <Text> ();
        txt.text = PlayerPrefs.GetInt("Money").ToString(); //Берём значение из Stars и переводим в строку.
    }
}
