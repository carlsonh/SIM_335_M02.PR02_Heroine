using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text[] tutTexts;

    public void UpdateUI(String tutName)
    {
        foreach (Text tut in tutTexts)
        {
            if (tut.gameObject.name == tutName)
            {
                tut.enabled = true;
            }
            else
            {
                tut.enabled = false;
            }
        }
    }
}
