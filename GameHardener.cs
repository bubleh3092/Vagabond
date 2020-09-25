using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHardener : MonoBehaviour
{
    private bool counter;

    void Update()
    {
        if (CubeJump.CountBlocks > 0)
        {
            if ((CubeJump.CountBlocks % 3 == 0) && (counter == false)) //Каждый  третий такт увеличивается сложность.
            {
                print("Harder");
                counter = true;
                Camera.main.GetComponent<Animation>().Play("Harder");
            }
            else if ((CubeJump.CountBlocks % 3 - 1 == 0) && (counter == true)) //Если номер такта не делится нацело на 3, сложность возвращается к обычной.
        {
                print("Easier");
                counter = false;
                Camera.main.GetComponent<Animation>().Play("Easier");
            }
        }
    }
}
