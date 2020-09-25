using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fallcube : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);
    }
    void Update()
    {
        transform.position += new Vector3(0, 0.1f, 0);
    }
}
  