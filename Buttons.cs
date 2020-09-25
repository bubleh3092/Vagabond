using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //Для возможности переходить между сценами.

public class Buttons : MonoBehaviour
{
    public Sprite SoundOn, SoundOff;
    public GameObject ShopBG, buttons, ShopCubes, SoundBearer;

    void Start()
    {
        if (gameObject.name == "Settings")
        {
            if (PlayerPrefs.GetString("Sound") == "off")
            {
                transform.GetChild(0).GetComponent<Image>().sprite = SoundOff;
                Camera.main.GetComponent<AudioListener>().enabled = false;
            }
        }
    }

    void OnMouseDown()   //Функция, увеличивающая размер кнопки при нажатии на неё
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
    void OnMouseUp() //Функция, возвращающая кнопке исходный размер при окончании нажатия на неё
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    void OnMouseUpAsButton()
    {
        GetComponentInParent<AudioSource>().Play();

        switch (gameObject.name)
        {
            case "Restart":
                SceneManager.LoadScene("main");
                break;

            case "Facebook":
                Application.OpenURL("https://www.facebook.com");
                break;

            case "Twitter":
                Application.OpenURL("https://https://twitter.com/?lang=ru");
                break;

            case "Google+":
                Application.OpenURL("https://https://www.google.ru");
                break;

            case "Settings":
                for (int i = 0; i < transform.childCount; i++) //Цикл от 0 до кол-ва дочерних объектов.
                {
                    transform.GetChild(i).gameObject.SetActive(!transform.GetChild(i).gameObject.activeSelf);
                }
                break;

            case "Sound":
                if (PlayerPrefs.GetString("Sound") == "off")
                {
                    GetComponent<Image>().sprite = SoundOn;
                    PlayerPrefs.SetString("Sound", "on");
                    Camera.main.GetComponent<AudioListener>().enabled = true;
                }
                else
                {
                    GetComponent<Image>().sprite = SoundOff;
                    PlayerPrefs.SetString("Sound", "off");
                    Camera.main.GetComponent<AudioListener>().enabled = false;
                }
                break;

            case "Shop":
                {
                    ShopBG.GetComponent<Animation>().Play();
                    ShopCubes.GetComponent<Animation>().Play();
                    ShopBG.SetActive(!ShopBG.activeSelf);
                    buttons.SetActive(false); // Чтобы нельзя было нажать на кнопки меню в магазине.
                    transform.localScale = new Vector3(1f, 1f, 1f); //Так как кнопка возвращается к нормальному размеру после того, как пользователь убирает палец с экрана, при открытии магазина она не успевает сжаться обратно.
                    SoundBearer.GetComponent<AudioSource>().Play();
                }
                break;

            case "ShopClose":
                {

                    ShopBG.SetActive(false);
                    buttons.SetActive(true); //Чтобы кнопки меню вернулись после выхода из магазина.
                    transform.localScale = new Vector3(1f, 1f, 1f); //Аналогично со строкой 78
                    SoundBearer.GetComponent<AudioSource>().Stop();
                }
                break;

        }
    }
}
