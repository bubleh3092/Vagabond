using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseCube : MonoBehaviour
{
    public GameObject CubeSeen, ChooseButton, MainCube, Bearer;
    public AudioClip Purchase;

    void OnMouseDown()
   {
        if (PlayerPrefs.GetInt ("Money") >= PlayerPrefs.GetInt("Price")) //Условие проверки того, хватает ли игроку звёзд на покупку нового куба.
        {
            PlayerPrefs.SetString(CubeSeen.GetComponent<ChooseCube>().ChosenCube, "Available"); //У CubeSeen берётся из скрипта ChooseCube переменная, в которой записано имя выбранного на данный момент куба, куб записывается в PlayerPrefs как доступный.
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt ("Money") - PlayerPrefs.GetInt("Price")); //Уменьшение кол-ва звёзд на 50 как результат покупки.
            MainCube.GetComponent<MeshRenderer>().material = GameObject.Find(CubeSeen.GetComponent<ChooseCube>().ChosenCube).GetComponent<MeshRenderer>().material; //Нахождение материала выбранного куба и передача его основному кубу.
            PlayerPrefs.SetString("Now Cube", CubeSeen.GetComponent<ChooseCube>().ChosenCube);
            Bearer.GetComponent<AudioSource>().clip = Purchase;
            Bearer.GetComponent<AudioSource>().Play();
            ChooseButton.SetActive(true);
            gameObject.SetActive(false);
        }
   }
}
