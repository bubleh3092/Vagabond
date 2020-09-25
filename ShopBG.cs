using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBG : MonoBehaviour
{
    public GameObject DetectClicks, allCubes;

    void OnEnable()
    {
        DetectClicks.SetActive(false);
        allCubes.SetActive(true);
    }

    void OnDisable()
    {
        DetectClicks.SetActive(true);
        allCubes.SetActive(false);
    }
}
