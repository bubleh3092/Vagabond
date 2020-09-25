using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MonoBehaviour
{
    public static bool jump, nextblock;
    public GameObject mainCube, losebuttons, buttons;
    private bool animate, lose;
    private float CompressionSpeed = 0.5f, StartTime, yPosCube;
    public static int CountBlocks;
    public AudioClip lost, menumusic;

    private void OnEnable()
    {
        nextblock = false;
        StartCoroutine(CanJump());
        jump = false;
        GetComponent<AudioSource>().clip = menumusic;
        GetComponent<AudioSource>().Play();
    }

    public static double RoundUp(double number, int digits)
    {
        var factor = Convert.ToDouble(Math.Pow(10, digits));
        return Math.Ceiling(number * factor) / factor;
    }

    void FixedUpdate() //Тот же update, но срабатывает каждые 0.02 секунды.
    {
        if (mainCube != null)
        {
            if (animate && mainCube.transform.localScale.y > 0.4f)
            {
                PressCube(-CompressionSpeed);
            }
            else if (!animate)
            {
                if (mainCube.transform.localScale.y < 1f)
                {
                    PressCube(CompressionSpeed * 3f);
                }
                else if (mainCube.transform.localScale.y != 1f)
                {
                    mainCube.transform.localScale = new Vector3(1f, 1f, 1f);
                }
            }
                if (mainCube.transform.position.y < -11f)
                {
                    Destroy(mainCube, 1f);
                    print("Player lose");
                    lose = true;
                }
        }
        if (lose == true)
        {
            PlayerLose();
        }
    }

    void PlayerLose()
    {
        if (losebuttons.activeSelf == false)
        {
            GetComponent<AudioSource>().clip = lost;
            GetComponent<AudioSource>().Play();
            losebuttons.SetActive(true);
            losebuttons.GetComponent<TextAppearance>().checkPos = 80;
        }

    }

    void OnMouseDown()
    {
        if (mainCube != null)
        {
            if ((mainCube.GetComponent<Rigidbody>() != null) && (nextblock == true)) //Если Rigidbody существует у maincube.
            {
                animate = true;
                StartTime = Time.time;
                yPosCube = Mathf.Round(mainCube.transform.localPosition.y); ;//Для отслеживания условий проигрыша (куб не спрыгнул с платформы)
                Console.WriteLine(yPosCube);
            }
        }
    }

    void OnMouseUp()
    {
        if (mainCube != null)
        {
            if ((mainCube.GetComponent<Rigidbody>() != null) && (nextblock == true)) //Если Rigidbody существует у maincube.
            {
                animate = false;
                jump = true;
                float force, diff;
                diff = Time.time - StartTime;
                if (diff < 3f)
                {
                    force = 190 * diff;
                }
                else
                {
                    force = 300f;
                }
                if (force < 60f)
                {
                    force = 60f;
                }
                mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.up * force);

                mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.right * -force);

                StartCoroutine(CheckCubePos()); //После прыжка идет запуск сопрограммы проверки одного из условий проигрыша(куб не спрыгнул с платформы)

                nextblock = false;
            }
        }
    }
    void PressCube (float force)
    {
        mainCube.transform.localPosition += new Vector3(0f, force * Time.deltaTime, 0f);
        mainCube.transform.localScale += new Vector3 (0f, force * Time.deltaTime, 0f);
    }
    IEnumerator CheckCubePos() //Сопрограмма, проверяющая, равна ли позиция куба по высоте прежней, т.е спрыгнул ли куб с платформы.
    {
        yield return new WaitForSeconds(1.5f);
        if (yPosCube == Mathf.Round(mainCube.transform.localPosition.y)) //Если позиция по высоте равна прежней, вывод уведомления о проигрыше.
        {
            lose = true;
        }
        else //В ином случае
        {
            while ((mainCube != null) && (!mainCube.GetComponent<Rigidbody>().IsSleeping())) //Если куб еще перемещается, назначает время следующей проверки через 0.05 секунд, пока он не остановится.
            {
                yield return new WaitForSeconds(0.05f);
            }
            if (lose == false) //Если не проигрыш, значит, куб за один прыжок оказался на следующей платформе.
            {
                nextblock = true;
                CountBlocks++; //Счет количества блоков.
                print("Next one"); //Указатель того, что куб переместился на следующую платформу.

            }
            if (mainCube != null)
            {
                mainCube.transform.localPosition = new Vector3(-1f, mainCube.transform.localPosition.y, mainCube.transform.localPosition.z); //Выравнивание  местоположения куба примерно по центру платформы.
                mainCube.transform.eulerAngles = new Vector3(0f, -90f, 0f); //Трансформация локальной системы координат куба в такое положение, чтобы он совершал прыжок только в нужную сторону.
            }
        }
    }

    IEnumerator CanJump()
    {
        while(mainCube.GetComponent<Rigidbody> () == false)
        {
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
        nextblock = true;
    }

}

