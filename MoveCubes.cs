using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubes : MonoBehaviour
{
    private bool moved = true;
    private Vector3 target;

    void Start()
    {
        target = new Vector3(-3.24f, 5f, 0f);
    }

    void Update()
    {
        if (CubeJump.nextblock == true)
        {
            if (transform.position != target)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 5f);
            }
            else if ((transform.position == target) && (moved == false))
            {
                target = new Vector3 (transform.position.x -2.75f, transform.position.y + 2.29f, transform.position.z);
                CubeJump.jump = false;
                moved = true;
            }
            if (CubeJump.jump) //Если совершен прыжок, можно дальше двигать платформу.
            {
                moved = false;
            }
        }
    }
}
