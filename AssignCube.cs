using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignCube : MonoBehaviour
{
    public GameObject MainCube, ChosenCube;
    void OnMouseDown()
    {
        if (MainCube != null)
        {
            MainCube.GetComponent<MeshRenderer>().material = GameObject.Find(ChosenCube.GetComponent<ChooseCube>().ChosenCube).GetComponent<MeshRenderer>().material; //Нахождение материала выбранного куба и передача его основному кубу.
            PlayerPrefs.SetString("Now Cube", ChosenCube.GetComponent<ChooseCube>().ChosenCube);
        }
    }
    
}
