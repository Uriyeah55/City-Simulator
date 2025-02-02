using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class City : MonoBehaviour
{
    public TMP_Text NotifText;
    public Button generateButton; 
    public PopulationManager populationManager;
    public List<Person> citizensList => populationManager.citizensList;

    
    public List<string> happinessNotif = new List<string>();

    void Start()
    {
      
    }
    void Update(){
        Debug.Log("CITY HAS " + citizensList.Count + " citixns");
    }

        //UpdateNotifications();

    void UpdateNotifications()
    {
        happinessNotif.Clear();
        NotifText.text = "";

        foreach (Person citizen in populationManager.citizensList)
        {
            if (citizen.hasGoodDay())
            {
                happinessNotif.Add("Citizen " + citizen.name + " has had a good day!");
            }
            happinessNotif.Add("Citizen " + citizen.name + " current happiness % is " + citizen.happinessPercentage);
        }

        foreach (string notification in happinessNotif)
        {
            NotifText.text += "\n" + notification;
        }

        Debug.Log("Average Happiness: " + populationManager.CalculateAverageHappiness());
    }
}
