using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroine : MonoBehaviour
{

    public IHeroineState heroineState = new StandingStateHeroine();
    public Rigidbody rb;

    public GameObject[] objects;

    public GameObject activeGO;
    public UIController uIController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        heroineState.Enter(this);
    }

    private void Update()
    {
        heroineState.Execute(this);
    }

    public void UpdateObject(String goName)
    {//Change out the object being shown
        //Debug.Log("Going to: " + heroineState.GetType().Name);

        //Update UI
        uIController.UpdateUI(heroineState.GetType().Name);

        foreach (GameObject heroineOption in objects)
        {
            if (goName == heroineOption.name)
            {
                heroineOption.SetActive(true);
                activeGO = heroineOption;
            }
            else
            {
                heroineOption.SetActive(false);
            }
        }
    }


}
