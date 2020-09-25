using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCube : MonoBehaviour
{
    public string ChosenCube;
    public GameObject Choose, Purchase, MainCube;
    public Text Price;
    private Text txt;

    void Start() //На старте изначальный куб должен быть доступен игроку, как уже приобретенный.
    {
        if (PlayerPrefs.GetString("Cube") != ("Available"))
        {
            PlayerPrefs.SetString("Cube", "Available");
        }
    }

    void OnTriggerEnter(Collider other) //Если куб попадает в ChooseCube.
    {
        ChosenCube = other.gameObject.name; //Запись имени куба в переменную, когда он попадает в пространство объекта CubeSeen.
        {
            other.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f); //Увеличить его объёмы для выделения выбранного куба.
        }
        if (PlayerPrefs.GetString(other.gameObject.name) == "Available")
        {
            Choose.SetActive(true);
            Purchase.SetActive(false); //Если куб открыт, кнопку "Выбрать" открыть, кнопку "Купить" закрыть.
        }
        else
        {
            Choose.SetActive(false);
            Purchase.SetActive(true); //В противном случае, наоборот, нужен доступ к кнопке "Купить".
        }
            switch (ChosenCube)
            {
                case "Cube":
                    PlayerPrefs.SetString("Price", "Obtained");
                    Price.text = PlayerPrefs.GetString("Price");
                    break;

                case "Sand cube":
                    if (Choose.active)
                    {
                        PlayerPrefs.SetString("Price", "Obtained");
                        Price.text = PlayerPrefs.GetString("Price");
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Price", 50);
                        Price.text = PlayerPrefs.GetInt("Price").ToString();
                    }
                    break;

                case "Salad cube":
                    if (Choose.active)
                    {
                        PlayerPrefs.SetString("Price", "Obtained");
                        Price.text = PlayerPrefs.GetString("Price");
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Price", 100);
                        Price.text = PlayerPrefs.GetInt("Price").ToString();
                    }
                    break;

                case "Violet cube":
                    if (Choose.active)
                    {
                        PlayerPrefs.SetString("Price", "Obtained");
                        Price.text = PlayerPrefs.GetString("Price");
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Price", 250);
                        Price.text = PlayerPrefs.GetInt("Price").ToString();
                    }
                    break;

                case "Sky cube":
                    if (Choose.active)
                    {
                        PlayerPrefs.SetString("Price", "Obtained");
                        Price.text = PlayerPrefs.GetString("Price");
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Price", 500);
                        Price.text = PlayerPrefs.GetInt("Price").ToString();
                    }
                    break;
            }

        }
    void OnTriggerExit(Collider other)
    {
        other.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
