using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMaterial : MonoBehaviour
{
    public GameObject[] Cubes;
    void Start()
    {
        for (int i = 0; i < Cubes.Length; i++)
        {
            if (PlayerPrefs.GetString("Now Cube") == Cubes[i].name) //Если выбранный куб равен имени куба из массива кубов, который перебирается в цикле.
            {
                GetComponent<MeshRenderer>().material = Cubes[i].GetComponent<MeshRenderer>().material; //Нахождение материала выбранного куба и передача его основному кубу.
                break;
            }
        }
    }
}
