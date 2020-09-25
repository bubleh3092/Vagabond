using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Подключаю Namespace для работы с пользовательским интерфейсом

public class GameConstitution : MonoBehaviour
{
    public GameObject[] cubesmas;
    public GameObject buttons, maincube, cubes, spawn_platforms, stars, money, sound;
    public Text playTxt, gameName, tutorial, topscore; //Задаю переменную класса Text
    public Animation Platform;
    public bool clicked;
    public AudioClip GameMusic;

    void OnMouseDown()
    {
        if (!clicked)
        {
            print("Click");

            clicked = true; //Чтобы скрипт сработал один раз, больше не нужно.

            StartCoroutine(DeleteCubes());

            playTxt.gameObject.SetActive(false); //Устранение playtxt вызовом метода SetActive класса GameObject.

            topscore.gameObject.SetActive(true); //Появление текста рекорда набранных очков.

            stars.SetActive(true);

            money.SetActive(true);

            if (sound.activeSelf)
            {
                for (int i = 0; i < sound.transform.parent.transform.childCount; i++) //Цикл от 0 до кол-ва дочерних объектов.
                {
                    sound.transform.parent.transform.GetChild(i).gameObject.SetActive(!sound.transform.parent.transform.GetChild(i).gameObject.activeSelf);
                }
            }

            tutorial.gameObject.SetActive(true); //Появление текста обучения аналогичным образом.

            gameName.text = "0"; //Присваивание  gameName класса text значения 0, чтобы вместо названия игры отображалось кол-во набранных очков.

            buttons.GetComponent<TextAppearance>().speed = -10f; //Получаем с помощью метода GetComponent доступ к TextAppearance  и меняем переменную speed, чтобы buttons двигались вниз.

            buttons.GetComponent<TextAppearance>().checkPos = -180f; //Аналогично меняем в скрипте TextAppearance переменную checkPos.

            maincube.GetComponent<Animation>().Play(); //С помощью метода GetComponent получаем доступ к Animation и проигрываем анимацию, которая присвоена объекту maincube.

            StartCoroutine(CubeToPlatform()); //Запуск сопрограммы для анимации превращения куба в платформу.

            cubes.GetComponent<Animation>().Play(); //Проигрываем анимацию у объекта cubes.

            GetComponent<AudioSource>().clip = GameMusic;

            GetComponent<AudioSource>().Play();
        }

        else if ((clicked == true) && (tutorial.gameObject.activeSelf)) //После первого прыжка убирается текст обучения c помощью состояния activeSelf.
        {

            tutorial.gameObject.SetActive(false);

        }
    }

    IEnumerator DeleteCubes()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            cubesmas[i].GetComponent<Fallcube>().enabled = true;
        }

        spawn_platforms.GetComponent<PlatformSpawner>().enabled = true;
    }

    IEnumerator CubeToPlatform()
    {
        yield return new WaitForSeconds(maincube.GetComponent<Animation>().clip.length + 0.5f);
        Platform.Play();
        maincube.AddComponent<Rigidbody>();
    }
}
