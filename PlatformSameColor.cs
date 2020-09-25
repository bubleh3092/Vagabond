using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSameColor : MonoBehaviour
{
    public AudioClip Fall;
    public bool first;

    void OnCollisionEnter(Collision other)

    {
        if ((other.gameObject.tag == "Cube") && (first))
        {
            other.gameObject.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().material.color;
            GetComponent<AudioSource>().clip = Fall;
            GetComponent<AudioSource>().Play();
        }
        if (first == false)
        {
            first = true;
        }
    }
}
