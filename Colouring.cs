using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colouring : MonoBehaviour
{
    public Color[] color;

    void Start()
    {
        GetComponent<MeshRenderer>().material.color = color [Random.Range (0, color.Length)];
    }

}
