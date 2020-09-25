using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectStars : MonoBehaviour
{
    public Text Stars;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Star")
        {
            Destroy(other.gameObject);
            PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") + 1);
            Stars.text = PlayerPrefs.GetInt("Money").ToString();
        }
    }
}
