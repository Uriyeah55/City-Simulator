using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Manager : MonoBehaviour
{
    public City currentCity;
    public TMP_Text NotifText;
    
    // Start is called before the first frame update
    void Start()
    {
            NotifText.text = "dpfign";

        currentCity=GetComponent<City>();
        printHappinessNews();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void printHappinessNews(){
        Debug.Log("city has " + currentCity.happinessNotif.Count + " news");
        foreach(string notificationCity in currentCity.happinessNotif)
        {
            NotifText.text += "\n" + notificationCity;
        }
    }
}
